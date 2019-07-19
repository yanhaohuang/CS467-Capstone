using UnityEngine;
using System.Collections;
using System;

public class InvincibilityPowerUp : MonoBehaviour {

    private IEnumerator coroutine;
    private BirdBehaviour Bird;

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

            coroutine = CountDown( collision );

            StartCoroutine(coroutine);

        } 

    }

    private IEnumerator CountDown( Collider2D player ){

        Bird = player.GetComponent<BirdBehaviour>();
        Bird.godMode = true;
        yield return new WaitForSeconds(10);
        Destroy( gameObject.transform.root.gameObject );
        Bird.godMode = false;

    }
}