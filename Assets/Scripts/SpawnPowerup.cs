using UnityEngine;
using System.Collections;

public class SpawnPowerup : MonoBehaviour {
	public GameObject[] powerups;
	public float max = 1.45f;
	public float min = 0.2f;
	public float time = 2f;

	void Start() {  
		InvokeRepeating("Spawn", time, time);
	}
	void Spawn() {  
		var spawnPoint = new Vector2(transform.position.x, Random.Range(max, min));
		Instantiate(powerups[Random.Range(0,powerups.Length)], spawnPoint, Quaternion.identity);
	}
}
