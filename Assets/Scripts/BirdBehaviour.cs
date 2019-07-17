using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BirdBehaviour : MonoBehaviour
{
    public static int score = 0;
    public int scale = 1;
    public static int maxScore = 999999999;

    public float flapSpeed = 175f;
    public float forwardSpeed = 1f;
    public float maxSpeed = 25f;

    private CircleCollider2D myCollider;

    public float gainSpeed = 0.2f;

    public float loseSpeed = 1f;

    private float counterSpeed = 0f;

    bool didFlap = false;
    Animator animator;
    public bool dead = false;
    public bool godMode = false;

    public AudioClip whoosh;
    public AudioClip splat;
    public AudioClip impact;
    AudioSource audioSource;

    private List<EnemyBehaviour> attachedEnemies;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = transform.GetComponentInChildren<Animator>();
        attachedEnemies = new List<EnemyBehaviour>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) didFlap = true;
        score = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("Player").transform.position.x) * scale;
        if (score > maxScore) dead = true;
        if (Time.timeScale == 0 && dead) Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (dead) return;
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * forwardSpeed);

        if (didFlap)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * flapSpeed);
            animator.SetTrigger("DoFlap");
            audioSource.PlayOneShot(whoosh, 0.8F);

            if (GetComponent<Rigidbody2D>().velocity.x <= maxSpeed)
            {
                counterSpeed = gainSpeed;
                forwardSpeed += counterSpeed;
                counterSpeed = 0f;
            }

            // Detach one enemy for every flap
            if (attachedEnemies.Any())
            {
                var mostRecentEnemy = attachedEnemies.OrderByDescending(x => x.index).FirstOrDefault();
                DetachEnemy(mostRecentEnemy);
                attachedEnemies.Remove(mostRecentEnemy);
            }

            didFlap = false;
        }

        if (GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            float angle = Mathf.Lerp(0, 90, (-GetComponent<Rigidbody2D>().velocity.y / 3f));
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            float angle = Mathf.Lerp(0, -90, (-GetComponent<Rigidbody2D>().velocity.y / 3f));
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var enemy = collision.gameObject.GetComponent<EnemyBehaviour>();
            if (!enemy.connectedPreviously)
            {
                audioSource.PlayOneShot(splat, 0.7F);
                if (GetComponent<Rigidbody2D>().velocity.x >= 2)
                {
                    counterSpeed = loseSpeed;
                    forwardSpeed -= counterSpeed;
                    counterSpeed = 0f;
                }

                // Enemies attach on collision
                AttachToPlayer(enemy, collision);
            }
        }
        if (collision.gameObject.tag == "Limit")
        {
            HandleDeath();
        }
    }

    public void AttachToPlayer(EnemyBehaviour enemy, Collision2D collision)
    {
        Debug.Log("Attached enemies count before attachment add: " + attachedEnemies.Count);

        collision.transform.parent = gameObject.transform;
        var enemyAttachment = gameObject.AddComponent<FixedJoint2D>();
        enemyAttachment.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
        enemyAttachment.autoConfigureConnectedAnchor = true;
        enemyAttachment.enableCollision = false;
        enemyAttachment.dampingRatio = 1;
        enemyAttachment.frequency = 0;
        enemyAttachment.breakForce = Mathf.Infinity;
        enemyAttachment.breakTorque = Mathf.Infinity;

        // Ensure this enemy can't be collided with again
        enemy.connectedPreviously = true;
        enemy.isConnected = true;
        enemy.index = attachedEnemies.Count;
        attachedEnemies.Add(enemy);

        Debug.Log("Attached enemies count after attachment add: " + attachedEnemies.Count);
    }

    public void HandleDeath()
    {
        if (godMode)
        {
            return;
        }

        foreach (var enemy in attachedEnemies)
        {
            DetachEnemy(enemy);
        }
        attachedEnemies.Clear();

        audioSource.PlayOneShot(impact, 1F);
        animator.SetTrigger("Death");
        dead = true;
    }

    public void DetachEnemy(EnemyBehaviour enemy)
    {
        var allAttachments = GetComponents<FixedJoint2D>();
        FixedJoint2D enemyAttachment = null;
        foreach (var attachment in allAttachments)
        {
            var currEnemy = attachment.connectedBody.gameObject.GetComponent<EnemyBehaviour>();
            if (currEnemy != null && currEnemy.index == enemy.index)
            {
                enemyAttachment = attachment;
            }
        }
        // Remove the joint and decouple from the parent/child relationship
        Destroy(enemyAttachment);
        enemy.transform.parent = null;
        enemy.isConnected = false;
    }
}