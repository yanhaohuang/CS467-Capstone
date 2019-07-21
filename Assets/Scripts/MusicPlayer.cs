﻿using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour {
	public AudioClip[] clips;
	private AudioSource audioSource;
	public AudioClip gameOver;
	BirdBehaviour bird;

	public AudioMixer audioMixer;

	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		bird = player_go.GetComponent<BirdBehaviour>();
		audioSource = GetComponent<AudioSource>();
		audioSource.loop = false;
	}

	private AudioClip GetRandomClip() {
		return clips [Random.Range (0, clips.Length)];
	}
	
	void Update () {
		AudioMixerGroup[] audioMixGroup = audioMixer.FindMatchingGroups("Master");
		if (!audioSource.isPlaying && Time.timeScale == 1 && !bird.dead) {
			audioSource.clip = GetRandomClip ();
			audioSource.outputAudioMixerGroup = audioMixGroup[0];
			audioSource.Play ();
		}
		if (bird.dead) {
			audioSource.Stop ();
		}			
	}
}
