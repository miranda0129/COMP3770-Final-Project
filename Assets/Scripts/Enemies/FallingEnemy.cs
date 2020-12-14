using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEnemy : MonoBehaviour
{
    public Material[] materials;
    public Level levelScript;

    private Renderer rend;
    private Collider coll;

    bool startedEnemy = false;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        coll = GetComponent<Collider>();
        coll.attachedRigidbody.useGravity = false;
        levelScript = GameObject.Find("Level").GetComponent<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!startedEnemy)
        {
            startedEnemy = true;

            //move to position
            rend.sharedMaterial = materials[1];
            transform.position = levelScript.GetPlayer().transform.position + new Vector3(0, 5, 0);

            StartCoroutine(FallDown());
        }
    }
    
    IEnumerator FallDown()
    {
        int i;
        for (i = 0; i<3; i++)
        {
            rend.sharedMaterial = materials[2];
            yield return new WaitForSeconds(0.5f);
            rend.sharedMaterial = materials[1];
            yield return new WaitForSeconds(0.5f);
        }

        if (i == 3)
        {
            coll.attachedRigidbody.useGravity = true;

            yield return new WaitForSeconds(2f);
            rend.sharedMaterial = materials[0];
            yield return new WaitForSeconds(2f);
            
            coll.attachedRigidbody.useGravity = false;
            startedEnemy = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 contact = collision.contacts[0].normal;

        //if enemy is hit on top, destroyy
        if(contact == -(transform.up))   Destroy(gameObject);
        

        if (contact == (transform.up) && collision.gameObject.name == "Player")
        {
            //for playground testing
            //REMOVE later
            //pls
            collision.gameObject.transform.position += new Vector3(0, 5, 0);

            //for level stuff
            if (levelScript == null) levelScript = GameObject.Find("Level").GetComponent<Level>();
            Destroy(collision.gameObject);
            levelScript.RespawnPlayer();
        }
    }
    
}
