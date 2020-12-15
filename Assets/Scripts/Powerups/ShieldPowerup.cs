using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildPowerup : Powerup
{
    public AudioClip shieldBlock;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        //set player material and shield flag in player script
        player.SetMaterial(player.powerupMats[4]);
        player.isShielded = true;
        shieldBlock = Resources.Load<AudioClip>("Audio Clips/shield"); //load audio clip
        Debug.Log("shield equipped");
    }

    //blocks one damage point
    void OnCollisionEnter(Collision col)
    {
        //block enemy projectile damage
        if (col.gameObject.layer == 11)
        {
            Debug.Log("Blocked by sheild");
            if (shieldBlock != null) { AudioSource.PlayClipAtPoint(shieldBlock, transform.position); }
            player.isShielded = false;
            RemovePowerup(gameObject.GetComponent<SheildPowerup>());//destory after block
        }
        //block enemy contact damage
        else if (col.gameObject.name == "DamageHitbox")
        {
            Debug.Log("Blocked by sheild");
            if (shieldBlock != null) { AudioSource.PlayClipAtPoint(shieldBlock, transform.position); }
            player.isShielded = false;
            RemovePowerup(gameObject.GetComponent<SheildPowerup>());//destory after block
        }
    }
}
