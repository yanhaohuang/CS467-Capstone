using UnityEngine;
using System.Collections;
using System;

public class InvincibilityPowerUp : PowerUp 
{

    protected override void powerUpEffect( BirdBehaviour player )
    {
        base.powerUpEffect( player );
        player.GetComponent<Rigidbody2D>().mass = 1.0f;
    }

}