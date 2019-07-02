using UnityEngine;
using System.Collections;

public class LightLooper : MonoBehaviour {
	float lightMax = 2.5f;
	float lightMin = -1f;

	void Start() {
		GameObject[] lights = GameObject.FindGameObjectsWithTag("Light");
		foreach (GameObject light in lights) {
			Vector3 pos = light.transform.position;
			pos.y = Random.Range(lightMin, lightMax);
			light.transform.position = pos;
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Vector3 pos = collider.transform.position;
		pos.x += 16f;
		pos.y = Random.Range(lightMin, lightMax);
		collider.transform.position = pos;
	}
}
