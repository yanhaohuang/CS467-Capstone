using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public static int score = 0;
	public static int highScore = 0;
	public int scale = 1;
	BirdBehaviour bird;

	void Start() {
		GetComponent<UnityEngine.UI.Text>().enabled = false;
		score = 0;
		highScore = PlayerPrefs.GetInt("highScore", 0);
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		bird = player_go.GetComponent<BirdBehaviour>();
	}
		 
	void Update () {
		if (Time.timeScale == 1 && !bird.dead) {
			score = Mathf.RoundToInt(GameObject.FindGameObjectWithTag("Player").transform.position.x)*scale;   
			if(score > highScore) highScore = score;
			PlayerPrefs.SetInt("highScore", highScore);
			GetComponent<UnityEngine.UI.Text>().enabled = true;
			GetComponent<UnityEngine.UI.Text> ().text = "Distance: " + score + " ";
		}
		if (Time.timeScale == 0) GetComponent<UnityEngine.UI.Text>().enabled = false;
	}
}
