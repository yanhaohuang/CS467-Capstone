using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
	public GameObject[] statics;
	public GameObject[] enemies;
	public GameObject[] chasers;
	public float max0 = 1.65f;
	public float max1 = 1.55f;
	public float min = 0.2f;
	public float time0 = 0.65f;
	public float time1 = 0.65f;
	public float time2 = 5f;

	void Start() {
        InvokeRepeating("SpawnStatic", time0, time0);
        InvokeRepeating("Spawn", time1, time1);
        InvokeRepeating("SpawnChaser", time2, time2);
    }
	void SpawnStatic() {  
		var spawnPoint = new Vector2(transform.position.x, max0);
		Instantiate(statics[Random.Range(0,statics.Length)], spawnPoint, Quaternion.identity);
	}
	void Spawn() {
		var spawnPoint = new Vector2(transform.position.x, Random.Range(max1, min));
		Instantiate(enemies[Random.Range(0,enemies.Length)], spawnPoint, Quaternion.identity);
	}	
	void SpawnChaser() {
		var spawnPoint = new Vector2(transform.position.x, Random.Range(max1, min));
		Instantiate(chasers[Random.Range(0,chasers.Length)], spawnPoint, Quaternion.identity);
	}	
}
