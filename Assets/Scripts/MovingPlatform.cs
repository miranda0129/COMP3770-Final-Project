using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{


    public float timer = 5.0f;
    public float pauseLength = 1.0f;

    private Vector3 startPos = Vector3.zero;
    private Vector3 endPos   = Vector3.zero;
    private Vector3 currPos;

    
    public GameObject startWaypoint;
    public GameObject endWaypoint;
    public int width = 1;

    private float elapsedTime = 0f;

    public bool leftToRight = true;
    private bool pause = false;

    [Header("DEBUG")]
    [Space(20)] public bool refreshGizmos;             // a little toggle to click to force OnValidate TODO: delete before submission.

    // Start is called before the first frame update
    void Start()
    {
            if (startWaypoint != null) startPos = startWaypoint.transform.position;
            if (endWaypoint != null) endPos = endWaypoint.transform.position;
            currPos = transform.position;
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

                transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / timer));

                if (Vector3.Distance(transform.position, endPos) <= 0.1f || elapsedTime >= timer) {

                leftToRight = false;
                    elapsedTime = 0.0f;
                    pause = true;

                }

            } else {

                transform.position = Vector3.Lerp(endPos, startPos, (elapsedTime / timer));

                if (Vector3.Distance(transform.position, startPos) <= 0.1f || elapsedTime >= timer) {

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
        Gizmos.DrawSphere(startPos, 0.2f);

        if(leftToRight) Gizmos.color = Color.green;
        else Gizmos.color = Color.white;
        Vector3 endingEdge = endPos;
        endingEdge.x += width;
        Gizmos.DrawSphere(endingEdge, 0.2f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(startPos, endingEdge);
        
	}

    // update position values on editor change.
    void OnValidate() {
        if(startWaypoint != null) startPos = startWaypoint.transform.position;
        if(endWaypoint != null)     endPos = endWaypoint.transform.position;
	}
}
