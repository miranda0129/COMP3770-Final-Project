using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPowerup : Powerup
{
    private float updated = 1;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        StartCoroutine(Timer(30));
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] objects = Physics.OverlapSphere(transform.position, 10f);
        foreach(Collider coll in objects)
        {
            if (coll.gameObject.name.Contains("Coin")) 
            {
                coll.gameObject.transform.position = Vector3.Lerp(coll.transform.position, transform.position, updated++/0.1f);
            }
        }
    }
}
