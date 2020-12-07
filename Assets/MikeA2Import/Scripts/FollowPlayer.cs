using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
     public GameObject player;
     private float timer = 1f;
     private float elapsedTime = 0f;
     private Vector3 currPos;

     void Start() {

          currPos = player.transform.position;

     }

    // Update is called once per frame
    void FixedUpdate()
    {
          elapsedTime += Time.deltaTime;

          if (player != null) {

               Vector3 newPosition = player.transform.position;
               newPosition.z -= 10.0f;
               newPosition.y += 10.0f;

               transform.position = newPosition;
               transform.LookAt(player.transform.position);

          } else {

               player = GameObject.Find("Player");

          }
    }
}
