using UnityEngine;
using System.Collections;

public class ForegroundLooper : MonoBehaviour {
	void Start() {}
	// Move the foreground 18.75 units to the right of wherever we collided with it
	void OnTriggerEnter2D(Collider2D collider) {
		Vector3 pos = collider.transform.position;
		pos.x += 18.75f;
		collider.transform.position = pos;
	}
}
