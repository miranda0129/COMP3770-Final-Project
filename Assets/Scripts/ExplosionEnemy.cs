using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnemy : MonoBehaviour
{
    public float health;
    public float damage;
    private Vector3 playerPosition;

    public GameObject explodingBall;
    public GameObject explodingRadius;
    public ParticleSystem boom;

    private bool exploding = false;

    float countdown = 5f;

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0 && !exploding)
        {
            exploding = true;

            //get player location and move there and show explosion radius
            playerPosition = GameObject.Find("Player").transform.position;
            explodingBall.transform.position = playerPosition;
            explodingRadius.SetActive(true);

            Explode();
        }
    }

    void Explode()
    {
        //one second is a bit too short
        //TO CHANGE
        StartCoroutine(waitSeconds(3f));
    }

    //waits any number of seconds
    IEnumerator waitSeconds(float seconds) { 
        yield return new WaitForSeconds(seconds);

        boom.Play();

        if (Physics.CheckSphere(playerPosition, 1.5f))
        {
            Rigidbody rb = GameObject.Find("Player").GetComponent<Rigidbody>();
            rb.AddExplosionForce(3000f, playerPosition, 1.5f, 1.0f);

        }

        explodingRadius.SetActive(false);
        countdown = 5f;
        exploding = false;
    }


}
