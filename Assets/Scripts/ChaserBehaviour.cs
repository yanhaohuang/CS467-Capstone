﻿using UnityEngine;
using System.Collections;

public class ChaserBehaviour : MonoBehaviour {
	public float speed = 2f;
	void start () {}
	void Update () {
		if (Time.timeScale == 0) Destroy(gameObject);
	}
	void FixedUpdate () {
		GetComponent<Rigidbody2D>().AddForce( Vector2.left * speed );
	}
	void OnCollisionEnter2D(Collision2D collider) {}	
}