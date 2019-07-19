﻿using UnityEngine;
using System.Collections;

public class SpawnPowerUps : MonoBehaviour {
	public GameObject SpeedPowerUp;
	public GameObject InvincibilityPowerUp;
	public GameObject HealthPowerUp;
	public float min = 0.2f;
    public float max = 1.48f;
	public float spawnTime = 1f;
	public float spawnDelay = 10f;

	void Start() {  
		//https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html
		InvokeRepeating("Spawn", spawnTime, spawnDelay);
	}
	void Spawn() {  
		var spawnPoint = new Vector2(transform.position.x, Random.Range(max, min));
		//https://docs.unity3d.com/ScriptReference/Random.Range.html
		int rand = Random.Range( 0, 3 );
		//https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
		switch (rand)
		{
			case 0:
				Instantiate(HealthPowerUp, spawnPoint, Quaternion.identity);
				break;
			case 1:
				Instantiate(HealthPowerUp, spawnPoint, Quaternion.identity);
				break;
			case 2:
				Instantiate(HealthPowerUp, spawnPoint, Quaternion.identity);
				break;
			default:
				break;
		}
	}
    
}
