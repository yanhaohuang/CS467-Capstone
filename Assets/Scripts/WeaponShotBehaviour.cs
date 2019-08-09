using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WeaponShotBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject explosion;
    public AudioClip explosionSound;
    public AudioMixer audioMixer;

    void Start()
    {
        
        // Set the forward transformation on this only so that we don't have to worry about working with the y-axis
        GetComponent<Rigidbody2D>().velocity = transform.forward * speed;
    }

    void Update()
    {
        // If time is 0 and we're not in the pause screen, destroy all instances of this object
        if (Time.timeScale == 0 && !PauseScreen.GamePaused)
        {
            Destroy(gameObject);
        }
        // Destroy the shot if it gets too far away
        Transform playerTransform = FindObjectOfType<PlayerBehaviour>().transform;
        float distance = Math.Abs(transform.position.x - playerTransform.position.x);
        Debug.Log("Distance: " + distance);
        if (distance > 5)
        {
            Destroy(gameObject);
        }
        // Speed the projectile up based on the current speed of the projectile and forward speed of the player
        GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.right * (speed + FindObjectOfType<PlayerBehaviour>().forwardSpeed));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // Add an explosion effect
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);

            // Getting the master mixer
            AudioMixerGroup[] audioMixGroup = audioMixer.FindMatchingGroups("Master");
            AudioSource soundfx = gameObject.GetComponent<AudioSource>();
            soundfx.outputAudioMixerGroup = audioMixGroup[0];
            // Play explosion sound effect
            soundfx.PlayOneShot(explosionSound, 1.0f);

            // Destroy enemy on contact
            Destroy(collision.gameObject);

            // Destroy weapon shot object
            Destroy(gameObject);
        }
        // Make it so that we don't have to deal with so many projectiles floating around
        if( collision.gameObject.tag == "Ceiling" || collision.gameObject.tag == "Ground" )
        {
            Destroy( gameObject ); 
        }
    }
}
