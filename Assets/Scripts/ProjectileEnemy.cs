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

    private LineRenderer aimLine;
    private bool reloading;
    private GameObject bullet;

    Vector3 playerPosition;

    Rigidbody rb;

   

    // Start is called before the first frame update
    void Start()
    {
        aimLine = GetComponent<LineRenderer>();
        aimLine.positionCount = 2;
        reloading = false;

    }
    IEnumerator FireGun(Ray ray)
    {
        bullet = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.LookRotation(ray.direction));
        //bullet.GetComponent<Rigidbody>().AddForce(ray.direction * bulletSpeed);
        bullet.GetComponent<Rigidbody>().velocity = ray.direction * bulletSpeed;
        reloading = true;
        print("Started Reloading...");
        yield return new WaitForSeconds(gunCooldown);

        reloading = false;
        print("Finished Reloading...");
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.Find("Player").transform.position;

        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(transform.position, playerPosition - transform.position); // Raycasts towards player position
        aimLine.SetPosition(0, transform.position);

        if (Physics.Raycast(ray, out hit, aggroDistance) && hit.collider.name == "Player") // If no obstacles between enemy and player, start shooting
        {           
            aimLine.SetPosition(1, playerPosition);

            if (reloading == false)
            {                           
                StartCoroutine(FireGun(ray));
            }
                                             
        }

    }

}

/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    public int bulletSpeed;
    public float aggroDistance;
    public LayerMask mask;

    Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.Find("Player").transform.position;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, (playerPosition - transform.position), out hit, aggroDistance, mask))
        {
            print("I see player");
            Debug.DrawRay(transform.position, (playerPosition - transform.position) * hit.distance, Color.red);
        }

        else
        {
            print("No player detected");
        }
            


    }

}

 */
