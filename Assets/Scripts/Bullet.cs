using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void onCollisionEnter2D(Collision2D collision)
    {
        print(collision.collider.name);
        print(collision.collider.tag);
        print(collision.gameObject.tag);
      /*  if (other.tag == "Player")
        {
            // damage player here
            print("Hit Player");

            Destroy(gameObject);
        }*/
    }


}