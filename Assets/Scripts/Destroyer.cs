using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
	void Start() {}
	
	// Destroy everything that this object that's tagged as an enemy or powerup
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Enemy" || collider.tag == "Powerup") {
			Destroy (collider.gameObject);
		}
	}
}
