using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShotBehaviour : MonoBehaviour
{
    public float speed;

    void Start()
    {
        if (Time.timeScale == 0 && !PauseScreen.GamePaused) Destroy(gameObject);
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
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
    }
}
