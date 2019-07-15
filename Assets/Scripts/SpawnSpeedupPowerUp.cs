using UnityEngine;
using System.Collections;

public class SpawnSpeedupPowerUp : MonoBehaviour {
	public GameObject powerUp;
	public float max = 1.48f;
	public float min = 0.2f;
    public float max1 = 1.27f;
	public float spawnTime = 0.5f;

	void Start() {  
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	void Spawn() {  
		var spawnPoint = new Vector2(transform.position.x, Random.Range(max1, min));
		Instantiate(powerUp, spawnPoint, Quaternion.identity);
	}
    
}
