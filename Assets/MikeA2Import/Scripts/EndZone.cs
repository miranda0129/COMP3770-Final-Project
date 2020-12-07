using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour {
     public Material endingColour;
     private MeshRenderer mesh;
     
     void Awake() {

          mesh = gameObject.GetComponent<MeshRenderer>();
  
     }

     void OnTriggerEnter(Collider col) {
          
          if(col.gameObject.name == "Player")
               mesh.material = endingColour;

     }
}
