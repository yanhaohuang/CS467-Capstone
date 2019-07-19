using UnityEngine;
using System.Collections;
using System;

public class SpeedupPowerUp : MonoBehaviour {

    private IEnumerator coroutine;

    void Update () {
		// Check for game being paused before we delete the enemies
		if (Time.timeScale == 0 && !PauseScreen.GamePaused ) 
        {
            Destroy(gameObject);
        }
	}
    /*
        If a player hits a speed power up then we disable the components that make it visible and
        interactable, start a coroutine that slows down time for 10 seconds and then destroys the powerup
     */
	void OnTriggerEnter2D( Collider2D collision )
    {

        if( collision.gameObject.tag == "Player" )
        {

            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            coroutine = CountDown();

            StartCoroutine(coroutine);

        } 

    }

    private IEnumerator CountDown(){

        Time.timeScale *= 0.5f;
        yield return new WaitForSeconds(10);
        Destroy( gameObject.transform.root.gameObject );
        Debug.Log("Powerup done");
        Time.timeScale = 1f;

    }
}