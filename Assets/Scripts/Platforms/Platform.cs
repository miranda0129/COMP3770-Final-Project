using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{


    [Header("Spawn Location")]
    public Vector3 spawnPoint;


    [Header("Attachment Points")]
    public Vector3 leftAnchor;
    public Vector3 rightAnchor;

    public int width = 1;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLeftAnchor(Vector3 left) { leftAnchor = left; }
    public void SetRightAnchor(Vector3 right) { rightAnchor = right; }

    void OnDrawGizmosSelected() {

        // Draw Player Spawn
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(spawnPoint, 0.5f);

        // Draw connection points
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(leftAnchor, 0.2f);
        Gizmos.DrawSphere(rightAnchor, 0.2f);
    }
}
