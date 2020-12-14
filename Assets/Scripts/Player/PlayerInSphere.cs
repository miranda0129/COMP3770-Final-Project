using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInSphere : MonoBehaviour
{
    public bool playerInSphere = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider col) {

        if(col.tag == "Player") {
            playerInSphere = true;
		}
	}

    public void OnTriggerExit(Collider col) {

        if(col.tag == "Player") playerInSphere = false;
	}
}
