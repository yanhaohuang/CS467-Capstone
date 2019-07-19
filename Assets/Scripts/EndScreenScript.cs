using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenScript : MonoBehaviour {
	public AudioClip gameOver;
	AudioSource audioSource;

	PlayerBehaviour player;
	public float deathCooldown = 2f;

	static int score;
	static int highScore;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		GetComponent<Text> ().enabled = false;
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		player = player_go.GetComponent<PlayerBehaviour>();
	}
	
	void Update () {
		if (player.dead) {			
			deathCooldown -= Time.deltaTime;
			if (deathCooldown <= 0f) {
				Time.timeScale = 0;
				GetComponent<Text>().enabled = true;
				audioSource.clip = gameOver;
				audioSource.loop = true;
				if (!audioSource.isPlaying) audioSource.Play();
				GetComponent<Text>().text = "Distance: " + Score.score + "\nBest Distance: " + Score.highScore +"\n\n\nTap to Restart";
				if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
					SceneManager.LoadScene("Scene");
				}
			}
		}
	}
}
