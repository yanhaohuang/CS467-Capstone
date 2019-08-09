using UnityEngine;
using System.Collections;

public class BackgroundLooper : MonoBehaviour {
	void Start() {}
	// Move the background 200 units to the right of wherever we collided with it
	void OnTriggerEnter2D(Collider2D collider) {
		Vector3 pos = collider.transform.position;
		pos.x += 200f;
		collider.transform.position = pos;
	}
}
