using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Powerup currentPowerup;

    public float speed = 10;
    public float JumpSpeed = 100.0f;
    public int maxJumps = 2;

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
    private LineRenderer lineRenderer;

    private PlayerInput inputManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentJumpTime = jumpTime;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        inputManager = gameObject.GetComponent<PlayerInput>();
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

        if (col.gameObject.layer == 11) // Originally had this in the bullet script but moved it here to have them all in one place.
        {
            Debug.Log("Player was damaged by projectile.");
            Destroy(col.gameObject);
            //StartCoroutine(iFrames());
        }

        if (col.gameObject.name == "HeadHitbox") // Destroy an enemy if we jump on it's head
        {
            Destroy(col.transform.parent.gameObject);
        }

        else if (col.gameObject.name == "DamageHitbox")
        {
            // Damage the player
            Debug.Log("Player was damaged by enemy contact.");

            //StartCoroutine(iFrames());
        }
    }

    //handle different powerups (and enemy?) collisions
    void OnTriggerEnter(Collider col) {

        // Teleport Pickup
        if(col.gameObject.name == "Teleport Powerup") {
            Debug.Log("Player hit teleport powerup");
            gameObject.AddComponent<TeleportPowerup>();
            currentPowerup = gameObject.GetComponent<TeleportPowerup>();
            Destroy(col.gameObject);
        }

        // Lazer Pickup
        if(col.gameObject.name == "Lazerbeam Powerup") {
           
            Debug.Log("Player hit lazerbeam powerup");
            gameObject.AddComponent<LazerBeamPowerup>();
            currentPowerup = gameObject.GetComponent<LazerBeamPowerup>();
            Destroy(col.gameObject);
        }
        //Extra jumps powerup
        if (col.gameObject.name == "Jump Powerup") {
            Debug.Log("Player hit jump powerup");
            gameObject.AddComponent<JumpPowerup>();
            currentPowerup = gameObject.GetComponent<JumpPowerup>();
            Destroy(col.gameObject);
        }
        //Throwable powerup
        if (col.gameObject.name == "Throwable Powerup")
        {
            Debug.Log("Player hit throwable powerup");
            gameObject.AddComponent<ThrowablePowerup>();
            currentPowerup = gameObject.GetComponent<ThrowablePowerup>();
            Destroy(col.gameObject);
        }
    }

    /* Controls */
    public void OnJump(InputValue input) {

        float jumpState = (input.Get<float>());     // 1 = is jumping, 0 = done
        
        if(jumpState == 1 && nJumps < maxJumps) {
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
