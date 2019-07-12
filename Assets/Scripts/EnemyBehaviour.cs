﻿using UnityEngine;
using System.Collections;
using System;

public class EnemyBehaviour : MonoBehaviour {
	public float speed = 1f;
	void start () {}
	void Update () {
		if (Time.timeScale == 0) Destroy(gameObject);
	}
	void FixedUpdate () {
		GetComponent<Rigidbody2D>().AddForce( Vector2.left * speed );
	}
	void OnCollisionEnter2D(Collision2D collision) {


        //Destroy (gameObject);
	}	
}