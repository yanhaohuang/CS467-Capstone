using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RangeDestructPowerUp : PowerUp
{
    public int canShoot;

    /*
        The player can fire this effect manually using the 'f' key
     */
    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Debug.Log("RangeDestructPowerup called");
            var playerBehavior = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdBehaviour>();
            playerBehavior.ToggleWeaponAnimation();
            RangeDestruct();
            canShoot--;
            if (canShoot <= 0)
            {
                removePowerUpEffect(Ship);
            }
        }
    }

    /*
        Locate all game objects in the scene, only target those that are in a range, then destroy them.
        Leaned on the Unity documentation to make this work https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
     */
    void RangeDestruct()
    {
        // TODO: Call animatorSetTrigger on player
        GameObject[] allSpawnedEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> enemiesToDestruct = new List<GameObject>();
        float maxRange = 100f;
        Vector3 position = transform.position;
        foreach (GameObject possibleTargets in allSpawnedEnemies)
        {
            Vector3 diff = possibleTargets.transform.position - position;
            float targetRange = diff.sqrMagnitude;
            Debug.Log("targetRange: " + targetRange);
            if (targetRange < maxRange)
            {
                enemiesToDestruct.Add(possibleTargets);
            }
        }

        foreach (GameObject go in enemiesToDestruct)
        {
            Debug.Log("ENEMY DESTROYED");
            Destroy(go);
        }
    }

    /*
        Set some variables when the player picks this up
     */
    protected override void powerUpEffect(BirdBehaviour player)
    {
        Debug.Log("RangeDestructPowerup powerup effect entered");
        base.powerUpEffect(player);
        destroyable = false;
        canShoot = 1;
    }

    /*
        After the player has fired this, then destroy it.
     */
    protected override void removePowerUpEffect(BirdBehaviour player)
    {
        destroyable = true;
        base.removePowerUpEffect(player);
    }

}