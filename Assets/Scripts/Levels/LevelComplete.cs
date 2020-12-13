using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{

    private Renderer rend;
    public Material[] mats;

    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other) {

        rend.material = mats[1];
        
	}

	private void OnTriggerExit(Collider other) {
        rend.material = mats[0];
	}
}
