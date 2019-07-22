using UnityEngine;
using System.Collections;
using System;

public class InvincibilityPowerUp : PowerUp 
{

    /*
        Set a player variable that allows them to avoid collisions with game objects tagged s enemies
     */
    protected override void powerUpEffect( BirdBehaviour player )
    {
        base.powerUpEffect( player );
        player.godMode = true;
    }

    /*
        Reset the player variable when we're done.
     */
    protected override void removePowerUpEffect( BirdBehaviour player )
    {
        base.removePowerUpEffect( player );
        player.godMode = false;
    }

}