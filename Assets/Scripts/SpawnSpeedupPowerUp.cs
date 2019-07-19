using UnityEngine;
using System.Collections;

public class SpawnSpeedupPowerUp : MonoBehaviour {
	public GameObject powerUp;
	public GameObject InvincibilityPowerUp;
	public float min = 0.2f;
    public float max = 1.48f;
	public float spawnTime = 1f;
	public float spawnDelay = 10f;

	void Start() {  
		InvokeRepeating("Spawn", spawnTime, spawnDelay);
	}
	void Spawn() {  
		var spawnPoint = new Vector2(transform.position.x, Random.Range(max, min));
		//https://docs.unity3d.com/ScriptReference/Random.Range.html
		int rand = Random.Range( 0, 2 );
		switch (rand)
		{
			case 0:
				Instantiate(powerUp, spawnPoint, Quaternion.identity);
				break;
			case 1:
				Instantiate(InvincibilityPowerUp, spawnPoint, Quaternion.identity);
				break;
			default:
				break;
		}
	}
    
}
