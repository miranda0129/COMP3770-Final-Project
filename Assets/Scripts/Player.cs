using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public float JumpSpeed = 100.0f;
    public float runMultiplier = 1.2f;

    private Rigidbody rb;
    private Vector3 movementVec;
    private int nJumps = 0;
    public float runAdjustment = 1.0f;

    InputAction runAction;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        runAction = GetComponent<PlayerInput>().actions["Run"];

    }

    void Update()
    {

    }

    void FixedUpdate() {

        // Apply movement
        rb.AddForce(movementVec * speed * runAdjustment);

    }

    void OnCollisionEnter(Collision col) {

        nJumps = 0;     // TODO: this will change as we have different colliders to do different things.
	}

    /* Controls */
    public void OnJump() {
        if(nJumps < 2) {
            rb.AddForce(Vector3.up * JumpSpeed, ForceMode.Impulse);
            nJumps++;
        }
	}

    public void OnMove(InputValue input) {

        Vector2 inputVec = input.Get<Vector2>();
        movementVec = new Vector3(inputVec.x, 0, inputVec.y);       // translate 2D vector into 3D space
        
	}

    public void OnRun(InputValue input) {

        if(input.isPressed) runAdjustment = runMultiplier;
        else runAdjustment = 1.0f;
	}
}
