using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public float speed = 1f;
	void start () {}
	void Update () {
		if (Time.timeScale == 0 && !PauseScreen.GamePaused ) Destroy(gameObject);
	}
	// Move the enemy at a fixed rate of speed in the opposite direction as the player
	void FixedUpdate () {
		GetComponent<Rigidbody2D>().AddForce( Vector2.left * speed );
	}
	void OnCollisionEnter2D(Collision2D collider) {}	
}