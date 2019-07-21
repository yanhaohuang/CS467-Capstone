using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RangeDestructPowerUp : PowerUp 
{

    public int canShoot;

    private void Update ()
    {
        if (Input.GetKeyDown ("f"))
        {
            RangeDestruct();
            canShoot--;
            if (canShoot <= 0)
            {
                removePowerUpEffect ( Bird );
            }
        }
    }

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

    protected override void powerUpEffect( BirdBehaviour player )
    {
        base.powerUpEffect( player );
        destoryable = false;
        canShoot = 1;
    }

    protected override void removePowerUpEffect( BirdBehaviour player )
    {
        destoryable = true;
        base.removePowerUpEffect( player );
    }

}