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
    private Vector3 mousePosition;
    public float jumpTime = 0.3f;
    private float currentJumpTime;
    public int nJumps = 0;
    public int teleCountRemaining = 5;
    private Rigidbody rb;
    public bool isSafe = false;
    private LineRenderer lineRenderer;

    private PlayerInput inputManager;
    private Level levelManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentJumpTime = jumpTime;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        inputManager = gameObject.GetComponent<PlayerInput>();
        levelManager = GameObject.Find("Level").GetComponent<Level>();
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

	private void LateUpdate() {

        // Clamp player to screen
        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 10));

        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, minScreenBounds.x, maxScreenBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, minScreenBounds.y, maxScreenBounds.y);
        transform.position = viewPos;

	}

	void OnCollisionEnter(Collision col) {
        
        if(col.gameObject.layer == LayerMask.NameToLayer("Level Geometry")) {
            nJumps = 0;
		}
        if (col.gameObject.layer == 11) // Originally had this in the bullet script but moved it here to have them all in one place.
        {
            Debug.Log("Player was damaged by projectile.");
            rb.constraints = RigidbodyConstraints.None;
            Destroy(col.gameObject);
            StartCoroutine(DieIn(2f));
            
            //StartCoroutine(iFrames(invincibilityTimeOnHit));
        }

        if (col.gameObject.name == "HeadHitbox" ) // Destroy an enemy if we jump on it's head
        {
            Destroy(col.transform.parent.gameObject);
        }

        if(col.gameObject.layer == LayerMask.NameToLayer("Weak Point")) {
            Destroy(col.gameObject);
		}

        else if (col.gameObject.name == "DamageHitbox")
        {
            // Damage the player
            Debug.Log("Player was damaged by enemy contact.");
            //StartCoroutine(iFrames(invincibilityTimeOnHit));
        }
    }

    //handle different powerups (and enemy?) collisions
    void OnTriggerEnter(Collider col) {

        // Teleport Pickup
        if(col.gameObject.name == "Teleport Powerup(Clone)") {
            Debug.Log("Player hit teleport powerup");
            gameObject.AddComponent<TeleportPowerup>();
            currentPowerup = gameObject.GetComponent<TeleportPowerup>();
            Destroy(col.gameObject);
        }

        // Lazer Pickup
        if(col.gameObject.name == "Lazerbeam Powerup(Clone)") {

            Debug.Log("Player hit lazerbeam powerup");
            gameObject.AddComponent<LazerBeamPowerup>();
            currentPowerup = gameObject.GetComponent<LazerBeamPowerup>();
            Destroy(col.gameObject);
        }

        //Extra jumps powerup
        if (col.gameObject.name == "Jump Powerup(Clone)") {
            Debug.Log("Player hit jump powerup");
            gameObject.AddComponent<JumpPowerup>();
            currentPowerup = gameObject.GetComponent<JumpPowerup>();
            Destroy(col.gameObject);
        }
        //Throwable powerup
        if (col.gameObject.name == "Throwable Powerup(Clone)")
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

    /* Powerup Timers */
    IEnumerator LazerTimer() {
        inputManager.SwitchCurrentActionMap("LazerMode");
        yield return new WaitForSeconds(30);
        inputManager.SwitchCurrentActionMap("Normal (No Powerups)");
        Debug.Log("Laserbeam powerup time out");
    }

    /* Invincibility Frames - still a WIP*/
    IEnumerator iFrames(float invincibilityTime)
    {
        Debug.Log("Invincibility period started");
        gameObject.layer = 10; // Changes the players layer to ignore enemies/projectiles during the invincibility period           TODO: Change from layer int to LayerMask.LayerFromName() or w.e.
        yield return new WaitForSeconds(invincibilityTime);
        gameObject.layer = 8; // Invincibility ends

        Debug.Log("Invincibility period ended");
    }

    public IEnumerator DieIn(float seconds) {
        yield return new WaitForSeconds(seconds);
        levelManager.RespawnPlayer();
        Destroy(gameObject);
	}


}
