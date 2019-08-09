using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour {
	public AudioClip[] clips;
	private AudioSource audioSource;
	PlayerBehaviour player;

	// Need to add the master mixer here and in the component view as well
	public AudioMixer audioMixer;

	void Start () {

		// Get the player object
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		player = player_go.GetComponent<PlayerBehaviour>();

		// Get the audio source
		audioSource = GetComponent<AudioSource>();
		audioSource.loop = false;
	}

	// Get a random audio clip from the array of audio clips
	private AudioClip GetRandomClip() {
		return clips [Random.Range (0, clips.Length)];
	}
	
	void Update () {
		// Getting the master mixer
		AudioMixerGroup[] audioMixGroup = audioMixer.FindMatchingGroups("Master");
		// And make sure we play through the proper mixer
		audioSource.outputAudioMixerGroup = audioMixGroup[0];

		// If the game is being played and the player isn't dead
		if (!audioSource.isPlaying && Time.timeScale == 1 && !player.dead) {

			// Get a random clip and play it
			audioSource.clip = GetRandomClip ();
			audioSource.Play ();
		}
		// Otherwise, if the player is dead, stop the music player
		if (player.dead) {
			audioSource.Stop ();
		}			
	}
}
