using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitEnemy : MonoBehaviour
{
    // Larger enemy type that splits into smaller versions when damaged - mostly uses the same code from the movement enemy + the multiplying mechanic

    public int damage;
    public float movementSpeed;
    public bool moveForward;
    public GameObject splitEnemy;

    private GameObject splitEnemy1;
    private GameObject splitEnemy2;

    Vector3 splitPosition = new Vector3(1.5f, 0, 0); // How far the spawned enemies will appear

    Vector3 splitVelocityRight = new Vector3(6, 1, 0);
    Vector3 splitVelocityLeft = new Vector3(-6, 1, 0);


    // Start is called before the first frame update
    void Start()
    {
        // Spawn the two enemies when the main enemy is defeated
        splitEnemy1 = Instantiate(splitEnemy, transform.position, transform.rotation);
        splitEnemy1.SetActive(false);
        splitEnemy1.transform.parent = transform.parent;
        splitEnemy2 = Instantiate(splitEnemy, transform.position, transform.rotation);
        splitEnemy2.SetActive(false);
        splitEnemy2.transform.parent = transform.parent;
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

    private void OnDestroy()
    {

        // Add velocity to them to they "pop out" instead of just appearing
        if(splitEnemy1 != null) { 
            splitEnemy1.SetActive(true); 
            splitEnemy1.GetComponent<Rigidbody>().velocity = splitVelocityRight;
        }

        if(splitEnemy2 != null) {
            splitEnemy2.SetActive(true);
            splitEnemy2.GetComponent<Rigidbody>().velocity = splitVelocityLeft;
        }
    }
}
