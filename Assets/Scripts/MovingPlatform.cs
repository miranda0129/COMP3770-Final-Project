using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{


     public float timer = 5.0f;
     public float pauseLength = 1.0f;

     public Vector3 startPos = Vector3.zero;
     public Vector3 endPos   = Vector3.zero;
     private Vector3 currPos;

     public GameObject startWaypoint;
     public GameObject endWaypoint;

     private float elapsedTime = 0f;

     private bool travelToEnd = true;
     private bool pause = false;

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

          } else if (travelToEnd) {

               transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / timer));

               if (Vector3.Distance(transform.position, endPos) <= 0.1f || elapsedTime >= timer) {

                    travelToEnd = false;
                    elapsedTime = 0.0f;
                    pause = true;

               }

          } else {

               transform.position = Vector3.Lerp(endPos, startPos, (elapsedTime / timer));

               if (Vector3.Distance(transform.position, startPos) <= 0.1f || elapsedTime >= timer) {

                    travelToEnd = true;
                    elapsedTime = 0.0f;
                    pause = true;
               }

          }
    }
}
