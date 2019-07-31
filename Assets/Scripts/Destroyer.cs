using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
	void Start() {}
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Enemy" || collider.tag == "Powerup") {
			Destroy (collider.gameObject);
		}
	}
}
