using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    void OnTriggerEnter(Collider col){
     
     if(col.gameObject.name == "Player") {
               GameObject.Destroy(gameObject);
          }
     }
}
