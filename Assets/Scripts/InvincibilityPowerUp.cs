using UnityEngine;
using System.Collections;
using System;

public class InvincibilityPowerUp : PowerUp 
{

    protected override void powerUpEffect( BirdBehaviour player )
    {
        base.powerUpEffect( player );
        player.godMode = true;
    }

    protected override void removePowerUpEffect( BirdBehaviour player )
    {
        base.removePowerUpEffect( player );
        player.godMode = false;
    }

}