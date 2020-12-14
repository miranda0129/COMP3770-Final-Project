using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildPowerup : Powerup
{

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {

        
        if (col.gameObject.layer == 11)
        {
            Debug.Log("Blocked by sheild");
            RemovePowerup(gameObject.GetComponent<SheildPowerup>());
        }

        else if (col.gameObject.name == "DamageHitbox")
        {
            Debug.Log("Blocked by sheild");
            RemovePowerup(gameObject.GetComponent<SheildPowerup>());
        }
    }
}
