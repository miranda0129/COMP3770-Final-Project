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
    private LineRenderer lineRenderer;
    private Vector3 mousePosition;

    private int teleCountRemaining;
    private PlayerInput inputManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentJumpTime = jumpTime;
        lineRenderer = GameObject.Find("Line Renderer").GetComponent<LineRenderer>();
        inputManager = gameObject.GetComponent<PlayerInput>();
    }

    void Update()
    {

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
        }

        if (col.gameObject.name == "HeadHitbox") // Destroy an enemy if we jump on it's head
        {
            Destroy(col.transform.parent.gameObject);
        }

        else if (col.gameObject.name == "DamageHitbox")
        {
            // Damage the player
            Debug.Log("Player was damaged by enemy contact.");
        }


    }

    void OnTriggerEnter(Collider col) {

        // Teleport Pickup
        if(col.gameObject.name == "Teleport Powerup") {
            Debug.Log("Player hit teleport powerup");
            GameObject.Destroy(col.gameObject);

            teleCountRemaining = 5;
            inputManager.SwitchCurrentActionMap("TeleportMode");
        }

        // Lazer Pickup
        if(col.gameObject.name == "Lazerbeam Powerup") {
            Debug.Log("Player hit lazerbeam powerup");
            GameObject.Destroy(col.gameObject);

            StartCoroutine(LazerTimer());

        }
        
       
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

    public void OnLazer(InputValue input) {

        if(input.isPressed) {
            lineRenderer.enabled = true;
            mousePosition = Mouse.current.position.ReadValue();
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(mousePosition + new Vector3(0, 0, 10)); //get click position
            clickPosition = new Vector3(clickPosition.x, clickPosition.y, 0);
            Vector3 direction = clickPosition - transform.position; //calculate ray direction from player to click point
            float maxDistance = direction.magnitude; // distance from player to click for raycast maxDistance

            //render laser 
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, clickPosition);
            lineRenderer.enabled = true;

            //play audio clip if available
            // if(pew != null) { AudioSource.PlayClipAtPoint(pew, transform.position); }

            //stores all hit objects
            RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, maxDistance); //cast ray

            //destory every enemy hit in between player & max distance
            for(int i = 0; i < hits.Length; i++) {
                RaycastHit hit = hits[i];
                Debug.Log("Hit object: " + hit.collider.gameObject.name);

                //destory only if tagged as enemy
                if(hit.collider.gameObject.tag == "Enemy") { Destroy(hit.collider.gameObject); }
            }
        } else {
            lineRenderer.enabled = false;
		}
    }

    public void OnTeleport() {
        //play audio clip if available
        // if(pop != null) { AudioSource.PlayClipAtPoint(pop, transform.position); }

        //get mouse position and set transform there
        mousePosition = Mouse.current.position.ReadValue();
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(mousePosition + new Vector3(0, 0, 10)); //get click position
        Debug.Log(clickPosition);
        transform.position = clickPosition;
        teleCountRemaining--;

        if(teleCountRemaining <= 0) {
            inputManager.SwitchCurrentActionMap("Normal (No Powerups)");
        }
    } 

    /* Powerup Timers */
    IEnumerator LazerTimer() {
        inputManager.SwitchCurrentActionMap("LazerMode");
        yield return new WaitForSeconds(30);
        inputManager.SwitchCurrentActionMap("Normal (No Powerups)");
        Debug.Log("Laserbeam powerup time out");
    }

}
