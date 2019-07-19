using UnityEngine;
using System.Collections;
using System;

public class SpeedupPowerUp : PowerUp 
{

    protected override void powerUpEffect( BirdBehaviour player )
    {
        base.powerUpEffect( player );
        Time.timeScale *= 0.5f;
    }

    protected override void removePowerUpEffect( BirdBehaviour player )
    {
        base.removePowerUpEffect( player );
        Time.timeScale = 1.0f;
    }

}