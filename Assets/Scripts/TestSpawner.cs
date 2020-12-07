using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    [Serializable]
    public struct GeometryTestObject {
       [SerializeField] public GameObject prefab;
       [SerializeField] public Vector3 spawnPosition;
	}

    public GeometryTestObject[] testObjects;

    public bool testOnStartUp = false;

    void Awake() {

		if(testOnStartUp) {

            foreach(GeometryTestObject testObject in testObjects) {
                if(testObject.prefab != null) {
                    GameObject instance = GameObject.Instantiate<GameObject>(testObject.prefab);
                    instance.transform.position = testObject.spawnPosition;
                }
            }
            
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }


    // Editor things
    void OnDrawGizmos() {
        foreach(GeometryTestObject obj in testObjects) {
            Gizmos.DrawIcon(obj.spawnPosition, "geometry.tif", true);
        }
        
	}
}
