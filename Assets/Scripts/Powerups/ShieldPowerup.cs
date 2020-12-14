using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildPowerup : Powerup
{

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        //set player material and shield flag in player script
        player.SetMaterial(player.powerupMats[4]);
        player.isShielded = true;
        Debug.Log("shield equipped");
    }

    //blocks one damage point
    void OnCollisionEnter(Collision col)
    {
        //block enemy projectile damage
        if (col.gameObject.layer == 11)
        {
            Debug.Log("Blocked by sheild");
            player.isShielded = false;
            RemovePowerup(gameObject.GetComponent<SheildPowerup>());//destory after block
        }
        //block enemy contact damage
        else if (col.gameObject.name == "DamageHitbox")
        {
            Debug.Log("Blocked by sheild");
            player.isShielded = false;
            RemovePowerup(gameObject.GetComponent<SheildPowerup>());//destory after block
        }
    }
}
