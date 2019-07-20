using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public string powerUpName;
    
    public AudioClip soundclip;

    public BirdBehaviour Bird;

    public bool expiresOnTime;
    private IEnumerator coroutine;

    void Update () {
		// Check for game being paused before we delete the enemies
		if (Time.timeScale == 0 && !PauseScreen.GamePaused ) 
        {
            Destroy(gameObject);
        }
	}
    protected virtual void OnTriggerEnter2D( Collider2D other )
    {

        // if the game object has been tagged as a player
        if( other.gameObject.tag == "Player" )
        {

            Bird = other.GetComponent<BirdBehaviour>();

            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            doSpecialEffects();

            if( expiresOnTime )
            {
                coroutine = CountDown( Bird );
                StartCoroutine(coroutine);
            }
            else 
            {
                powerUpEffect( Bird );
                Destroy( gameObject.transform.root.gameObject );
            }

        } 
        // Otherwise don't do anything
        else 
        {
            return;
        }
    }

    protected virtual void powerUpEffect( BirdBehaviour player )
    {
        Debug.Log( "Added" );
    }

    protected virtual void removePowerUpEffect( BirdBehaviour player )
    {
        Debug.Log( "Removed" );
    }

    protected virtual void doSpecialEffects( )
    {
       AudioSource soundfx = gameObject.GetComponent<AudioSource>();
       soundfx.PlayOneShot(soundclip, 1.0f);
    }

    protected virtual IEnumerator CountDown( BirdBehaviour player )
    {

        powerUpEffect( player );
        yield return new WaitForSeconds(10);
        Destroy( gameObject.transform.root.gameObject );
        removePowerUpEffect( player );

    }
}
