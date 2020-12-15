using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    public int damage;
    public int bulletSpeed;
    public float aggroDistance;
    public GameObject bulletPrefab;
    public float gunCooldown;
    public LayerMask layersToIgnore; // Not sure if there was a better way to do this but this is so the raycast doesn't get blocked by other parts of the enemy

    private LineRenderer aimLine; // Visual line of where the enemy is looking, can remove later if we want
    private bool reloading;
    private GameObject bullet;

    Level levelManager;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        aimLine = GetComponent<LineRenderer>();
        aimLine.positionCount = 2;
        reloading = false;

        levelManager = GameObject.Find("Level").GetComponent<Level>();
        player = levelManager.GetPlayer();

    }
    IEnumerator FireGun(Ray ray) // Fires a bullet along the raycast line which bounces
    {
        bullet = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.LookRotation(ray.direction));
        bullet.GetComponent<Rigidbody>().velocity = ray.direction * bulletSpeed;
        reloading = true;

        yield return new WaitForSeconds(gunCooldown);

        reloading = false;
    }

    // Update is called once per frame
    void Update() {

        if(player == null && levelManager != null) player = levelManager.GetPlayer();

        if(player != null) {
            aimLine.enabled = false;
            RaycastHit hit = new RaycastHit();
            Ray ray = new Ray(transform.position, player.position - transform.position); // Raycasts towards player position


            if(Physics.Raycast(ray, out hit, aggroDistance, ~layersToIgnore) && hit.collider.tag == "Player") // If no obstacles between enemy and player, start shooting
            {
                aimLine.enabled = true;
                aimLine.SetPosition(0, transform.position);
                aimLine.SetPosition(1, hit.point);

                if(reloading == false) {
                    StartCoroutine(FireGun(ray));
                }

            }
        }
    }

}