﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class EndScreenScript : MonoBehaviour {
	public AudioClip gameOver;
	AudioSource audioSource;
	public AudioMixer audioMixer;

	BirdBehaviour bird;
	public float deathCooldown = 2f;

	static int score;
	static int highScore;

	PauseScreen pause;

	void Start () {
		AudioMixerGroup[] audioMixGroup = audioMixer.FindMatchingGroups("Master");
		audioSource = GetComponent<AudioSource>();
		audioSource.outputAudioMixerGroup = audioMixGroup[0];
		GetComponent<Text> ().enabled = false;
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		bird = player_go.GetComponent<BirdBehaviour>();
	}
	
	void Update () {
		if (bird.dead) {
			pause = GameObject.FindObjectOfType(typeof(PauseScreen)) as PauseScreen;			
			deathCooldown -= Time.deltaTime;
			if (deathCooldown <= 0f) {
				Time.timeScale = 0;
				GetComponent<Text>().enabled = true;
				audioSource.clip = gameOver;
				audioSource.loop = true;
				if (!audioSource.isPlaying) audioSource.Play();
				GetComponent<Text>().text = "Distance: " + Score.score + "\nBest Distance: " + Score.highScore +"\n\nTap to Restart" + "\n\nPress 'M' for Menu";
				if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && !PauseScreen.GamePaused ) {
					SceneManager.LoadScene("Scene");
				} else if( Input.GetKeyDown( KeyCode.M ) ){
					pause.Pause();
				}
			}
		}
	}
}
