using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class EndScreenScript : MonoBehaviour {
	public AudioClip gameOver;
	AudioSource audioSource;

	// Our audio mixer
	public AudioMixer audioMixer;


	PlayerBehaviour player;
	public float deathCooldown = 2f;

	static int score;
	static int highScore;

	// Pause screen object
	PauseScreen pause;

	void Start () {
		// Load up the audio mixer, get the clip, and play it
		AudioMixerGroup[] audioMixGroup = audioMixer.FindMatchingGroups("Master");
		audioSource = GetComponent<AudioSource>();
		audioSource.outputAudioMixerGroup = audioMixGroup[0];

		// Clear the end-screen text until it's needed
		GetComponent<Text> ().enabled = false;

		// Get the player object in the scene
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		player = player_go.GetComponent<PlayerBehaviour>();
	}
	
	void Update () {
		if (player.dead) {

			// Pull in our pause screen script so we can call a method in it
			pause = GameObject.FindObjectOfType(typeof(PauseScreen)) as PauseScreen;	

			// Wait past the player's death for a short period and then
			deathCooldown -= Time.deltaTime;
			if (deathCooldown <= 0f) {
				Time.timeScale = 0;

				// Show our end screen text and play the ending music
				GetComponent<Text>().enabled = true;
				audioSource.clip = gameOver;
				audioSource.loop = true;
				if (!audioSource.isPlaying) audioSource.Play();

				GameObject PauseButton = GameObject.FindGameObjectWithTag("GameUI");
				PauseButton.GetComponent<Image>().enabled = false;
				GetComponent<Text>().text = "Distance: " + Score.score + "\nBest Distance: " + Score.highScore +"\n\nTap to Restart";

				if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && !PauseScreen.GamePaused ) {
					SceneManager.LoadScene("Scene");
				}
		
			}
		}
	}
}
