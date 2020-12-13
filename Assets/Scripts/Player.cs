using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public float JumpSpeed = 100.0f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;
    public float runMultiplier = 1.2f;
    private float runAdjustment = 1.0f;

    private Vector3 movementVec;
    private Vector3 jumpVec;
    public float jumpTime = 0.3f;
    private float currentJumpTime;
    public int nJumps = 0;

    private Rigidbody rb;
    public bool isSafe = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentJumpTime = jumpTime;
    }

    void FixedUpdate() {

        // Apply movement
        rb.AddForce(movementVec * speed * runAdjustment, ForceMode.Force);

        // Apply Jumps
        currentJumpTime += Time.deltaTime;
        if(currentJumpTime < jumpTime) {
            rb.AddForce(jumpVec * JumpSpeed, ForceMode.Impulse);

        }

        //faster falling
        if(rb.velocity.y < 0) {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        //control jump height by length of time jump button held
        if(jumpVec == Vector3.zero && rb.velocity.y > 0) {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        

    }

    void OnCollisionEnter(Collision col) {

        nJumps = 0;     // TODO: this will change as we have different colliders to do different things.
        // rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    }

    /* Controls */
    public void OnJump(InputValue input) {

        float jumpState = (input.Get<float>());     // 1 = is jumping, 0 = done
        
        if(jumpState == 1 && nJumps < 2) {
            jumpVec = Vector3.up;
            currentJumpTime = 0.0f;
            nJumps++;
        } else jumpVec = Vector3.zero;
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
