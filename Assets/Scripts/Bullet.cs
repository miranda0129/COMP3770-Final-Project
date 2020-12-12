using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody body;
    public int bouncecount;
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime); // Despawns the bullet after a set amount of time
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Damage player here

            Destroy(gameObject);
        }

        bouncecount--;

        if (bouncecount <= 0)
            Destroy(gameObject);
    }


}