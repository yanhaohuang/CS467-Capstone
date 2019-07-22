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
    private void Update ()
    {
        if (Input.GetKeyDown ("f"))
        {
            RangeDestruct();
            canShoot--;
            if (canShoot <= 0)
            {
                removePowerUpEffect ( Ship );
            }
        }
    }

    /*
        Locate all game objects in the scene, only target those that are in a range, then destroy them.
        Leaned on the Unity documentation to make this work https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
     */
    void RangeDestruct()
    {
        GameObject[] AllSpawnedEnemies;
        List<GameObject> EnemiesToDestruct = new List<GameObject>();
        AllSpawnedEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float distance = 10f;
        Vector3 position = transform.position;
        foreach (GameObject go in AllSpawnedEnemies)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                EnemiesToDestruct.Add( go );
            }
        }

        foreach (GameObject go in EnemiesToDestruct )
        {
            Destroy( go );
        }

    }

    /*
        Set some variables when the player picks this up
     */
    protected override void powerUpEffect( BirdBehaviour player )
    {
        base.powerUpEffect( player );
        destoryable = false;
        canShoot = 1;
    }

    /*
        After the player has fired this, then destroy it.
     */
    protected override void removePowerUpEffect( BirdBehaviour player )
    {
        destoryable = true;
        base.removePowerUpEffect( player );
    }

}