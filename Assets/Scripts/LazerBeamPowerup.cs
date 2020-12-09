using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class LazerBeamPowerup : MonoBehaviour
{
    public Vector3 clickPosition;
    public AudioClip pew;

    private LineRenderer lineRenderer;
    private Vector3 direction;
    private float maxDistance;


    // Start is called before the first frame update
    void Start()
    {
        pew = Resources.Load<AudioClip>("Audio Clips/laser_pew");

        lineRenderer = GameObject.Find("Player").GetComponent<LineRenderer>();
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;

        if(gameObject.name == "Player") {
            StartCoroutine(Timer());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //behaviour change for when player has equipped
        if (gameObject.name == "Player") {
           

            //shoot laserbeam on click
            if (Input.GetMouseButtonDown(0)) {
                clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,10)); //get click position
                clickPosition = new Vector3(clickPosition.x, clickPosition.y, 0);
                direction = clickPosition - transform.position; //calculate ray direction from player to click point
                maxDistance = direction.magnitude; // distance from player to click for raycast maxDistance

                //render laser 
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, clickPosition);
                lineRenderer.enabled = true;

                //play audio clip if available
                if (pew != null) { AudioSource.PlayClipAtPoint(pew, transform.position); }

                //stores all hit objects
                RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, maxDistance);//cast ray

                //destory every enemy hit in between player & max distance
                for(int i=0; i<hits.Length; i++)
                {
                    RaycastHit hit = hits[i];
                    Debug.Log("Hit object: " + hit.collider.gameObject.name);

                    //destory only if tagged as enemy
                    if( hit.collider.gameObject.tag == "Enemy" ) { Destroy(hit.collider.gameObject); }
                }

            }

            //stop showing laser when mouse not clicked
            if (Input.GetMouseButtonUp(0)) { lineRenderer.enabled = false; }
        }
    }

    //timer to disable powerup after 30 seconds
    IEnumerator Timer()
    {
        Debug.Log("Timer started");
        yield return new WaitForSeconds(30);
        Destroy(gameObject.GetComponent<LazerBeamPowerup> ());
        Debug.Log("Laserbeam powerup time out");
    }

}
