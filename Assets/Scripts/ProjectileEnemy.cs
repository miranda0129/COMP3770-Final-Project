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

    Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        aimLine = GetComponent<LineRenderer>();
        aimLine.positionCount = 2;
        reloading = false;

    }
    IEnumerator FireGun(Ray ray) // Fires a bullet along the raycast line which bounces
    {
        bullet = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.LookRotation(ray.direction));
        //bullet.GetComponent<Rigidbody>().AddForce(ray.direction * bulletSpeed);
        bullet.GetComponent<Rigidbody>().velocity = ray.direction * bulletSpeed;
        reloading = true;

        yield return new WaitForSeconds(gunCooldown);

        reloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.Find("Player").transform.position;

        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(transform.position, playerPosition - transform.position); // Raycasts towards player position
        aimLine.SetPosition(0, transform.position);

        if (Physics.Raycast(ray, out hit, aggroDistance, ~layersToIgnore) && hit.collider.name == "Player") // If no obstacles between enemy and player, start shooting
        {           
            aimLine.SetPosition(1, playerPosition);

            if (reloading == false)
            {                           
                StartCoroutine(FireGun(ray));
            }
                                             
        }

    }

}