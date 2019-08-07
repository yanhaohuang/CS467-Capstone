using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShotBehaviour : MonoBehaviour
{
    public float speed;

    void Start()
    {
        if (Time.timeScale == 0 && !PauseScreen.GamePaused) Destroy(gameObject);
        // Set the forward transformation on this only so that we don't have to worry about working with the y-axis
        GetComponent<Rigidbody2D>().velocity = transform.forward * speed;
    }

    void Update()
    {
        // Destroy the shot if it gets too far away
        Transform playerTransform = FindObjectOfType<PlayerBehaviour>().transform;
        float distance = transform.position.x - playerTransform.position.x;
        Debug.Log("Distance: " + distance);
        if (distance > 10)
        {
            Destroy(gameObject);
        }
        // Speed the projectile up based on the current speed of the projectile and forward speed of the player
        GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.right * (speed + FindObjectOfType<PlayerBehaviour>().forwardSpeed));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // Destroy enemy on contact
            Destroy(collision.gameObject);
            // Destroy weapon shot object
            Destroy(gameObject);
        }
        // Make it so that we don't have to deal with so many projectiles floating around
        if( collision.gameObject.tag == "Ceiling" || collision.gameObject.tag == "Ground" )
        {
            Destroy( gameObject ); 
        }
    }
}
