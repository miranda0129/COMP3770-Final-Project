using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public float JumpSpeed = 100.0f;
    public float thrust = 1.0f;
    private Rigidbody rb;

    public bool setVelocity;
    public Vector3 velocity;
    public Vector3 currentVelocity;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (setVelocity)
        {
            setVelocity = false;
            rb.velocity = velocity;
        }

        if (Input.GetKeyUp(KeyCode.Space))
            Jump();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left * thrust, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right * thrust, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.forward * thrust, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.back * thrust, ForceMode.Impulse);
    }

    void Jump()
    {
        rb.AddForce(new Vector3(0, 1, 0) * JumpSpeed, ForceMode.Impulse);
    }
}
