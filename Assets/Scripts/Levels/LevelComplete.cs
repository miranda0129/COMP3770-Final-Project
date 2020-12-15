using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{

    private Renderer rend;
    public Material[] mats;
    private Level levelManager;

    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        levelManager = GameObject.Find("Level").GetComponent<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other) {

        rend.material = mats[1];
        levelManager.LevelComplete();
        
	}

	private void OnTriggerExit(Collider other) {
        rend.material = mats[0];
	}
}
