using UnityEngine;
using System.Collections;
using System;

public class SpeedupPowerUp : PowerUp 
{

    /*
        Slow time down by 50%
     */
    protected override void powerUpEffect( BirdBehaviour player )
    {
        base.powerUpEffect( player );
        Time.timeScale *= 0.5f;
    }

    /*
        Speed time back up to 100%
     */
    protected override void removePowerUpEffect( BirdBehaviour player )
    {
        base.removePowerUpEffect( player );
        Time.timeScale = 1.0f;
    }

}