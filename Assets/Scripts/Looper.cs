using UnityEngine;
using System.Collections;

public class Looper : MonoBehaviour {
	void Start() {}
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Limit" || collider.tag == "Ceiling") {
			Vector3 pos = collider.transform.position;
			pos.x -= 8.75f;
			collider.transform.position = pos;
		}
	}
}
