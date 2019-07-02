using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
	public GameObject enemy;
	public float max = 1.48f;
	public float min = 0.2f;
    public float max1 = 1.27f;
	public float spawnTime = 0.65f;
	public float spawnTime1 = 0.65f;

	void Start() {  
		InvokeRepeating("Spawn", spawnTime, spawnTime);
		InvokeRepeating("Spawn1", spawnTime1, spawnTime1);
	}
	void Spawn() {  
		var spawnPoint = new Vector2(transform.position.x, Random.Range(max1, min));
		Instantiate(enemy, spawnPoint, Quaternion.identity);
	}
	void Spawn1() {
		var spawnPoint1 = new Vector2(transform.position.x, max);
		Instantiate(enemy, spawnPoint1, Quaternion.identity);
	}	
}
