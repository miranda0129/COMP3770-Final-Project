using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private Level levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("Level").GetComponent<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        levelManager.IncreaseScore(1);
        Destroy(gameObject);
    }
}
