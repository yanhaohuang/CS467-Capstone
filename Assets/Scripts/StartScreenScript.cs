using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenScript : MonoBehaviour {
	public AudioClip menuMusic;
	AudioSource audioSource;
	void Start () {
		Time.timeScale = 0;
		GetComponentInChildren<SpriteRenderer>().enabled = true;
		GetComponent<Text>().enabled = true;
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = menuMusic;
		audioSource.loop = true;
		audioSource.Play();
	}
	
	void Update () {
		if (Time.timeScale == 0 && (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0))) {
			Time.timeScale = 1;
			GetComponentInChildren<SpriteRenderer> ().enabled = false;
			GetComponent<Text> ().enabled = false;
			audioSource.Stop ();
		}
	}
}
