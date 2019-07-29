using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public string powerUpName;

    public AudioClip soundclip;

    public BirdBehaviour Ship;

    public bool expiresOnTime;
    public bool destroyable = false;
    private IEnumerator coroutine;

    void Update()
    {
        // Check for game being paused before we delete the enemies
        if (Time.timeScale == 0 && !PauseScreen.GamePaused)
        {
            Destroy(gameObject);
        }
    }

    /*
        When a player hits a powerup, disable the visible/interactable components of the powerup
        and apply the powerup either immediately or over the course of time.
     */
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {

        // if the game object has been tagged as a player
        if (other.gameObject.tag == "Player")
        {

            Ship = other.GetComponent<BirdBehaviour>();

            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            doSpecialEffects();

            if (expiresOnTime)
            {
                Debug.Log("Powerup expires on time");
                coroutine = CountDown(Ship);
                StartCoroutine(coroutine);
            }
            else
            {
                Debug.Log("Powerup does not expire on time");
                powerUpEffect(Ship);
            }

        }
        // Otherwise don't do anything
        else
        {
            return;
        }
    }

    /*
        Kind of a stub function - the specific powerup classes do most of this work
     */
    protected virtual void powerUpEffect(BirdBehaviour player)
    {
        Debug.Log("Added");
    }

    /*
        Destroy the powerup
     */
    protected virtual void removePowerUpEffect(BirdBehaviour player)
    {
        if (destroyable && !expiresOnTime)
        {
            Destroy(gameObject.transform.root.gameObject);
            Debug.Log("Got it");
        }
    }

    /*
        Play an audio clip when hitting a powerup
     */
    protected virtual void doSpecialEffects()
    {
        AudioSource soundfx = gameObject.GetComponent<AudioSource>();
        soundfx.PlayOneShot(soundclip, 1.0f);
    }

    /*
        If the powerup is one that should work over a period of time then we 
        call the effect, wait for 10 seconds, destroy the game object and remove the powerup effect if needed
     */
    protected virtual IEnumerator CountDown(BirdBehaviour player)
    {

        powerUpEffect(player);
        yield return new WaitForSeconds(10);
        removePowerUpEffect(player);
        Destroy(gameObject.transform.root.gameObject);

    }
}
