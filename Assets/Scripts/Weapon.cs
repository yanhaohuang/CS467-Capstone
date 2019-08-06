using UnityEngine;
using System.Collections;
using System;

public class Weapon : PowerUpBase
{

    /*
        Set a player variable that allows them to avoid collisions with game objects tagged s enemies
     */
    protected override void powerUpEffect(PlayerBehaviour player)
    {
        base.powerUpEffect(player);
        player.hasWeapon = true;
    }

    /*
        Reset the player variable when we're done.
     */
    protected override void removePowerUpEffect(PlayerBehaviour player)
    {
        base.removePowerUpEffect(player);
        player.hasWeapon = false;
    }

    /*
        Set out animation
     */
    protected override void doSpecialEffects(PlayerBehaviour player)
    {
        base.doSpecialEffects(player);
        player.setAnimation("Weapon");

    }

}