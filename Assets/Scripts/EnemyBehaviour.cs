using UnityEngine;
using System.Collections;
using System;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 1f;
    public bool isConnected = false;
    public bool connectedPreviously = false;
    public int index;

    void start() { }
    void Update()
    {
        if (Time.timeScale == 0) Destroy(gameObject);
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // If collision is with another enemy and the other enemy is attached to the player, attach this enemy to player as well
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
            var otherEnemy = collision.gameObject.GetComponent<EnemyBehaviour>();
            if (otherEnemy.isConnected)
            {
                // TODO: Connect to player here using function in BirdBehaviour
                Debug.Log("Enemy has attachment to player");
                var player = GameObject.FindObjectOfType<BirdBehaviour>();
                if (player != null)
                {
                    player.AttachToPlayer(gameObject.GetComponent<EnemyBehaviour>(), collision);
                }
            }
        }
        // TODO: Good point for progress report
        // TODO: Make attached enemies go grey, be destroyed, or similar? How to handle attached enemies on death
        if (collision.gameObject.tag == "Limit")
        {
            var player = GameObject.FindObjectOfType<BirdBehaviour>();
            player.HandleDeath();
        }
    }
}