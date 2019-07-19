using UnityEngine;
using System.Collections;

public class ForegroundLooper : MonoBehaviour {
	void Start() {}
	void OnTriggerEnter2D(Collider2D collider) {
		Vector3 pos = collider.transform.position;
		pos.x += 18.75f;
		collider.transform.position = pos;
	}
}
