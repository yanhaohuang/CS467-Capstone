using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HealthPowerUp : PowerUp 
{
    protected override void powerUpEffect( BirdBehaviour player )
    {
        base.powerUpEffect( player );
        player.transform.localScale = new Vector3( 1, 1, 1 );
        // Well this was all a waste of time. 
        /*int results;
        List<Collider2D> allAttached = new List<Collider2D>();
        results = player.transform.parent.GetComponent<Rigidbody2D>().GetAttachedColliders( allAttached );
        Debug.Log( results );
        foreach(Collider c in player.transform.root.gameObject.GetComponents<Collider> ()) {
                c.enabled = true;
                Debug.Log( c.tag );
        }*/
        //Debug.Log( player.GetComponent<Rigidbody2D>().GetAttachedColliders() );
    }

}