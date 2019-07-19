using UnityEngine;
using System.Collections;

public class BirdBehaviour : MonoBehaviour
{
    public static int score = 0;
    public int scale = 1;
    public static int maxScore = 999999999;

    public float flapSpeed = 175f;
    public float forwardSpeed = 1f;
    public float maxSpeed = 25f;

    private CircleCollider2D myCollider;

    public float gainSize = 1f;
    public float gainMass = 0.2f;
    public float gainSpeed = 0.2f;

    public float loseSize = 0.2f;
    public float loseMass = 0.04f;
    public float loseSpeed = 1f;

    public float counter = 0f;
    public float counterMass = 0f;
    private float counterSpeed = 0f;

    bool didFlap = false;
    Animator animator;
    public bool dead = false;
    public bool godMode = false;

    public AudioClip whoosh;
    public AudioClip splat;
    public AudioClip impact;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = transform.GetComponentInChildren<Animator>();
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
            if (GetComponent<Rigidbody2D>().mass >= 1.04f)
            {
                //counter = loseSize;
                //counterMass = loseMass;
                GetComponent<Rigidbody2D>().mass -= counterMass;
                transform.localScale -= new Vector3(counter, counter, counter);
                counterMass = 0f;
                counter = 0f;
            }
            if (GetComponent<Rigidbody2D>().velocity.x <= maxSpeed)
            {
                counterSpeed = gainSpeed;
                forwardSpeed += counterSpeed;
                counterSpeed = 0f;
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
            if (godMode) return;
            audioSource.PlayOneShot(splat, 0.7F);
            counter = gainSize;
            counterMass = gainMass;
            GetComponent<Rigidbody2D>().mass += counterMass;
            transform.localScale += new Vector3(counter, counter, counter);
            counter = 0f;
            counterMass = 0f;
            if (GetComponent<Rigidbody2D>().velocity.x >= 2)
            {
                counterSpeed = loseSpeed;
                forwardSpeed -= counterSpeed;
                counterSpeed = 0f;
            }

            // Enemies attach on collision
            collision.transform.parent = transform;
            var enemyAttachment = collision.gameObject.AddComponent<FixedJoint2D>();
            enemyAttachment.connectedBody = GetComponent<Rigidbody2D>();
        }
        if (collision.gameObject.tag == "Limit")
        {
            if (godMode) return;
            audioSource.PlayOneShot(impact, 1F);
            animator.SetTrigger("Death");
            dead = true;
        }
    }
}