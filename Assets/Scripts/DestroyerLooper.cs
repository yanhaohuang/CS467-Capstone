using UnityEngine;
using System.Collections;

public class DestroyerLooper : MonoBehaviour {
	void Start() {}
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Enemy") {
			Destroy (collider.gameObject);
		}
		if (collider.tag != "Light") {
			Vector3 pos = collider.transform.position;
			pos.x += 8.75f;
			collider.transform.position = pos;
		}
	}
}
