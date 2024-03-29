﻿using UnityEngine;
using System.Collections;

public class SpawnPowerup : MonoBehaviour {

	// Powerup game objects - associated with these variables in the Unity editor
	public GameObject Boost;
	public GameObject Barrier;
	public GameObject Bomb;
	public GameObject Health;
    public GameObject Weapon;

	// Location and time variables for instantiation location
    public float min = 0.2f;
    public float max = 1.48f;
	public float spawnTime = 1f;
	public float spawnDelay = 10f;

	/*
		Create a powerup in random space every 10 seconds.
	 */
	void Start() {  
		//https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html
		InvokeRepeating("Spawn", spawnTime, spawnDelay);
	}
	void Spawn() {  
		// pick a point
		var spawnPoint = new Vector2(transform.position.x, Random.Range(max, min));
		//https://docs.unity3d.com/ScriptReference/Random.Range.html
		// generate a random number
		int rand = Random.Range( 0, 5 );
		//https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
		// based on the point and random number, instantiate one of the four powerups
		switch (rand)
		{
			case 0:
				Instantiate(Bomb, spawnPoint, Quaternion.identity);
				break;
			case 1:
				Instantiate(Barrier, spawnPoint, Quaternion.identity);
				break;
			case 2:
				Instantiate(Boost, spawnPoint, Quaternion.identity);
				break;
			case 3:
				Instantiate(Health, spawnPoint, Quaternion.identity);
				break;
            case 4:
                Instantiate(Weapon, spawnPoint, Quaternion.identity);
                break;
            default:
				break;
		}
	}
}