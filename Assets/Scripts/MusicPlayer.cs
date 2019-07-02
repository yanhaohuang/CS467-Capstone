using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	public AudioClip[] clips;
	private AudioSource audioSource;
	public AudioClip gameOver;
	BirdBehaviour bird;

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
		if (!audioSource.isPlaying && Time.timeScale == 1 && !bird.dead) {
			audioSource.clip = GetRandomClip ();
			audioSource.Play ();
		}
		if (bird.dead) {
			audioSource.Stop ();
		}			
	}
}
