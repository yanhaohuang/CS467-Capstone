using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	public AudioClip[] clips;
	private AudioSource audioSource;
	PlayerBehaviour player;

	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		player = player_go.GetComponent<PlayerBehaviour>();
		audioSource = GetComponent<AudioSource>();
		audioSource.loop = false;
	}

	private AudioClip GetRandomClip() {
		return clips [Random.Range (0, clips.Length)];
	}
	
	void Update () {
		if (!audioSource.isPlaying && Time.timeScale == 1 && !player.dead) {
			audioSource.clip = GetRandomClip ();
			audioSource.Play ();
		}
		if (player.dead) {
			audioSource.Stop ();
		}			
	}
}
