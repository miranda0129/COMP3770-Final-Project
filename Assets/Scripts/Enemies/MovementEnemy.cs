using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    // Basic enemy type that moves and collides with level geometry

    public int damage;
    public float movementSpeed;
    public bool moveForward;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveForward)
        {
            transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
        }

        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9) // Check for collision against wall and reverse direction
        {
            moveForward = !moveForward;
        }
    }

    private void OnApplicationQuit() {
        Destroy(gameObject);
	}
}
