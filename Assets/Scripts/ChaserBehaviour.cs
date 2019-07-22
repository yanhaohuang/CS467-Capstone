using UnityEngine;
using System.Collections;

public class ChaserBehaviour : MonoBehaviour
{
    public float speed = 2f;
    void start() { }
    void Update()
    {
        if (Time.timeScale == 0) Destroy(gameObject);
    }
    void FixedUpdate()
    {
        // TODO: The direction of the force should change depending on where the Chaser is in relation to the Player
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed);
        // TODO: Chase player here
        // TODO: Use this code to show first step of this working, but that it needs improvement
        Transform playerTransform = FindObjectOfType<PlayerBehaviour>().transform;
        var step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, step);
    }
    void OnCollisionEnter2D(Collision2D collider) { }
}