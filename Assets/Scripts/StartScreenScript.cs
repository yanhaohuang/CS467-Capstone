﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class StartScreenScript : MonoBehaviour {
	public AudioClip menuMusic;
	AudioSource audioSource;

	// Add the audio mixer here and in the component view as well
	public AudioMixer audioMixer;
	void Start () {
		// Get the audio mixer
		AudioMixerGroup[] audioMixGroup = audioMixer.FindMatchingGroups("Master");
		Time.timeScale = 0;
		GetComponentInChildren<SpriteRenderer>().enabled = true;
		GetComponent<Text>().enabled = true;
		audioSource = GetComponent<AudioSource>();
		// Play clip through the audio mixer
		audioSource.outputAudioMixerGroup = audioMixGroup[0];
		audioSource.clip = menuMusic;
		audioSource.loop = true;
		audioSource.Play();
	}
	
	void Update () {
		if ( Time.timeScale == 0 && (Input.GetKeyDown (KeyCode.Space)) && !PauseScreen.GamePaused ) {
			Time.timeScale = 1;
			GetComponentInChildren<SpriteRenderer> ().enabled = false;
			GetComponent<Text> ().enabled = false;
			audioSource.Stop ();
		}
	}
}
