using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public static int score = 0;
	public static int highScore = 0;
	public int scale = 1;
	PlayerBehaviour player;

	void Start() {
		// Keep the score off the screen at first
		GetComponent<Text>().enabled = false;
		// Set the score 
		score = 0;
		// Set the first high score of the session
		highScore = PlayerPrefs.GetInt("highScore", 0);
		// Get the player
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		player = player_go.GetComponent<PlayerBehaviour>();
	}
		 
	void Update () {
		// While we're playing
		if (Time.timeScale == 1 && !player.dead) {
			// Get the sccore based on their current position
			score = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("Player").transform.position.x)*scale; 
			// See if this score is the new high score  
			if(score > highScore) highScore = score;
			// Set the player's high score
			PlayerPrefs.SetInt("highScore", highScore);
			// Show the score
			GetComponent<Text>().enabled = true;
			GetComponent<Text> ().text = "Distance: " + score + " ";
		}
		// Remove from the screen if the game is done or paused
		if (Time.timeScale == 0 || PauseScreen.GamePaused ) GetComponent<Text>().enabled = false;
	}
}
