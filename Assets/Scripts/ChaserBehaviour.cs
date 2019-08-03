using UnityEngine;
using System.Collections;

public class ChaserBehaviour : MonoBehaviour
{
    public float speed = 1.5f;
    void start() { }
    void Update()
    {
        if (Time.timeScale == 0) Destroy(gameObject);
    }
    void FixedUpdate()
    {
        Transform playerTransform = FindObjectOfType<PlayerBehaviour>().transform;

        // The facing should change depending on where the Chaser is in relation to the Player
        if (playerTransform.position.x < transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        var step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, step);
    }
    void OnCollisionEnter2D(Collision2D collider) { }
}