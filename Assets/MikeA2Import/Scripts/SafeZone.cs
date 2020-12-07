using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    void OnTriggerEnter(Collider col) {
          
          if(col.gameObject.name == "Player"){
            // col.gameObject.GetComponent<MovePlayer>().isSafe = true;        // O.G
            col.gameObject.GetComponent<Player>().isSafe = true;               // Playground
               Debug.Log("Player is safe!");
          }
     }

     void OnTriggerExit(Collider col) {
          if(col.gameObject.name == "Player") {
               
           // col.gameObject.GetComponent<MovePlayer>().isSafe = false;         // O.G
            col.gameObject.GetComponent<Player>().isSafe = false;               // Playground
               Debug.Log("Player is no longer safe!");
          }
     }
}
