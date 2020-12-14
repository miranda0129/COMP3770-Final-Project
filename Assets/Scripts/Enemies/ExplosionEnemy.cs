using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnemy : MonoBehaviour
{
    public float health;
    public float damage;
    public Level levelManager;
    private Transform player;

    private Renderer enemyRenderer;
    public Renderer explodingRadiusRenderer;
    public PlayerInSphere explosionCollider;
    private SphereCollider enemyCollider;
    public ParticleSystem boom;

    public Material[] mats;             // 0 = see through, 1 = can be damaged.

    private bool exploding = false;

    float countdown = 5f;

    void Start() {
        enemyCollider = gameObject.GetComponent<SphereCollider>();
        enemyCollider.enabled = false;
        levelManager = GameObject.Find("Level").GetComponent<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0 && !exploding)
        {
            exploding = true;
            if(enemyRenderer == null) enemyRenderer = gameObject.GetComponent<Renderer>();
            enemyRenderer.material = mats[0];
            enemyCollider.enabled = false;

            //get player location and move there and show explosion radius
            if(player == null) player = levelManager.GetPlayer();
            else if(levelManager == null) player = GameObject.Find("Player").transform;      // for playground

            transform.position = player.position;
            explodingRadiusRenderer.enabled = true;
            Debug.Log("Im in here");

            Explode();
        }
    }

    void Explode()
    {
        //one second is a bit too short
        //TO CHANGE
        StartCoroutine(waitSeconds(1f));
    }

    //waits any number of seconds, then explodes
    IEnumerator waitSeconds(float seconds) { 
        yield return new WaitForSeconds(seconds);

        explodingRadiusRenderer.enabled = false;
        boom.Play();

        if(explosionCollider.playerInSphere) {
            Rigidbody rb = player.GetComponent<Rigidbody>();
            player.GetComponent<Player>().TakeDamage();
            rb.AddExplosionForce(5000f, transform.position, 1.5f, 1.0f);
        }

        enemyRenderer.material = mats[1];
        enemyCollider.enabled = true;
        countdown = 5f;
        exploding = false;
    }


}
