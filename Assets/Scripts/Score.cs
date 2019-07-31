using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public static int score = 0;
	public static int highScore = 0;
	public int scale = 1;
	PlayerBehaviour player;

	void Start() {
		GetComponent<Text>().enabled = false;
		score = 0;
		highScore = PlayerPrefs.GetInt("highScore", 0);
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		player = player_go.GetComponent<PlayerBehaviour>();
	}
		 
	void Update () {
		if (Time.timeScale == 1 && !player.dead) {
			score = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("Player").transform.position.x)*scale;   
			if(score > highScore) highScore = score;
			PlayerPrefs.SetInt("highScore", highScore);
			GetComponent<Text>().enabled = true;
			GetComponent<Text> ().text = "Distance: " + score + " ";
		}
		if (Time.timeScale == 0) GetComponent<Text>().enabled = false;
	}
}
