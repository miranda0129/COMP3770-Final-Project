using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPowerup : Powerup
{
    private float timeToDestination = 15f;
    private float elapsedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        player.SetMaterial(player.powerupMats[4]);
        StartCoroutine(Timer(30, this));
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] objects = Physics.OverlapSphere(transform.position, 10f);
        foreach(Collider coll in objects)
        {
            if (coll.gameObject.name.Contains("Coin")) 
            {
                elapsedTime += Time.deltaTime;
                coll.gameObject.transform.position = Vector3.Lerp(coll.transform.position, transform.position, (elapsedTime/timeToDestination));
                if(elapsedTime >= timeToDestination) elapsedTime = 0;
            }
        }
    }
}
