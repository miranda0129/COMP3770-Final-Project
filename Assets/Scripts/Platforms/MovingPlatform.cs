using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Platform))]
public class MovingPlatform : MonoBehaviour
{

    private Platform platform;
    [Header("Timers")]
    private int width;
    public float timeToDestination = 5.0f;
    public float pauseLength = 1.0f;
    private float elapsedTime = 0f;


    [Header("Waypoints")]
    public GameObject startWaypoint;
    public GameObject endWaypoint;


    [Tooltip("Should the platform start at the starting waypoint, or the ending waypoint?")]
    public bool leftToRight = true;

    // platform position information
    private Vector3 startPos = Vector3.zero;
    private Vector3 endPos   = Vector3.zero;
    private Vector3 currPos  = Vector3.zero;
    private Vector3 endingEdge = Vector3.zero;
    private bool pause = false;


    [Header("DEBUG")]
    [Space(20)] public bool refreshGizmos;             // a little toggle to click to force OnValidate TODO: delete before submission.

    // Start is called before the first frame update
    void Start()
    {
        platform = gameObject.GetComponent<Platform>();

        if (startWaypoint != null) startPos = startWaypoint.transform.position;
        if (endWaypoint != null) endPos = endWaypoint.transform.position;
        currPos = transform.position;

        endingEdge = endPos;
        endingEdge.x += width;

        platform.SetRightAnchor(endingEdge);
    }

    // Update is called once per frame
    void Update() {


        elapsedTime += Time.deltaTime;
          
        if(pause){

            if(elapsedTime >= pauseLength){
                pause = false;
                elapsedTime = 0.0f;
            }

        } else if (leftToRight) {

            transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / timeToDestination));

            if (Vector3.Distance(transform.position, endPos) <= 0.1f || elapsedTime >= timeToDestination) {

                leftToRight = false;
                elapsedTime = 0.0f;
                pause = true;

            }

        } else {

            transform.position = Vector3.Lerp(endPos, startPos, (elapsedTime / timeToDestination));

            if (Vector3.Distance(transform.position, startPos) <= 0.1f || elapsedTime >= timeToDestination) {

                leftToRight = true;
                elapsedTime = 0.0f;
                pause = true;
            }

        }
    }


    // Just editor things.
    void OnDrawGizmosSelected() {

        if(leftToRight) Gizmos.color = Color.white;
        else Gizmos.color = Color.green;
        Gizmos.DrawSphere(startPos, 0.1f);

        if(leftToRight) Gizmos.color = Color.green;
        else Gizmos.color = Color.white;
        Vector3 endingEdge = endPos;
        endingEdge.x += width;
        Gizmos.DrawSphere(endingEdge, 0.1f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(startPos, endingEdge);
        
	}

    // update position values on editor change.
    void OnValidate() {

        if(startWaypoint != null) startPos = startWaypoint.transform.position;
        if(endWaypoint != null)     endPos = endWaypoint.transform.position;

        platform = gameObject.GetComponent<Platform>();
        width = platform.width;
        endingEdge = endPos;
        endingEdge.x += width;

        platform.SetRightAnchor(endingEdge);
    }
}
