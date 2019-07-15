using UnityEngine;
using System.Collections;
using System;

public class SpeedupPowerUp : MonoBehaviour {


    void Update () {
		// Check for game being paused before we delete the enemies
		if (Time.timeScale == 0 && !PauseScreen.GamePaused ) 
        {
            Destroy(gameObject);
        }
	}
	void OnTriggerEnter( Collider collision )
    {

        if( collision.gameObject.tag == "Player" )
        {

            Debug.Log( "Hit" );

        }

    }
}