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
        if (isConnected && collision.gameObject.tag == "Limit" )
        {
            var player = GameObject.FindObjectOfType<BirdBehaviour>();
            player.HandleDeath();
        }
    }
}