using UnityEngine;
using System.Collections;
using System;

public class EnemyBehaviour : MonoBehaviour {
	public float speed = 1f;
	void start () {}
	void Update () {
		// Check for game being paused before we delete the enemies
		if (Time.timeScale == 0 && !PauseScreen.GamePaused ) Destroy(gameObject);
	}
	void FixedUpdate () {
		GetComponent<Rigidbody2D>().AddForce( Vector2.left * speed );
	}
	void OnCollisionEnter2D(Collision2D collision) {

        Destroy (gameObject);
	}	
}