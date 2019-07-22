using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HealthPowerUp : PowerUp 
{
    /*
        Reset the player's size to their original size when they pick this up.
     */
    protected override void powerUpEffect( BirdBehaviour player )
    {
        base.powerUpEffect( player );
        player.transform.localScale = new Vector3( 1, 1, 1 );
    }

}