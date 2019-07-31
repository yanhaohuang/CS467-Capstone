using UnityEngine;
using System.Collections;

public class BackgroundLooper : MonoBehaviour {
	void Start() {}
	void OnTriggerEnter2D(Collider2D collider) {
		Vector3 pos = collider.transform.position;
		pos.x += 200f;
		collider.transform.position = pos;
	}
}
