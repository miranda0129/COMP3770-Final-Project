using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{

    [Serializable]
    public struct EnemySpawn {
        [SerializeField] public GameObject enemyPrefab;
        [SerializeField] public Vector3 spawnPosition;
	}

    [Serializable]
    public struct CollectableSpawn {
        [SerializeField] public GameObject collectablePrefab;
        [SerializeField] public Vector3 spawnPosition;

	}


    [Header("SpawnLocations")]
    public Vector3 playerSpawn;
    public CollectableSpawn[] collectables;
    public EnemySpawn[] enemies;

   
    [Header("Attachment Points")]
    public Vector3 leftAnchor;
    public Vector3 rightAnchor;
    public Vector3 toptionalAnchor = Vector3.negativeInfinity;
    public Vector3 botionalAnchor = Vector3.negativeInfinity;
    public bool topAnchorAvailable = false;
    public bool bottomAnchorAvailable = false;
    
    void OnEnable() {
        if(toptionalAnchor != Vector3.negativeInfinity) topAnchorAvailable = true;
        if(botionalAnchor != Vector3.negativeInfinity) bottomAnchorAvailable = true;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    // Determine where to place Section based on Specified Anchor
    public Vector3 GetRelativeAnchorPositon(Vector3 attachedAnchor) {
        return Vector3.zero;
	}

    /// <summary>
    /// The furthest active section will have the active midpoint.
    /// </summary>
    public void ActivateMidPoint() { }

    // Accessors / Mutators
    public Vector3 GetRightAnchor() { return rightAnchor; }

    // In scene view, display the position of various things to make it quicker/easier to iterate.
    void OnDrawGizmosSelected() {

        // Draw Player Spawn
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(playerSpawn, 0.5f);

        // Draw Enemy Spawn
        Gizmos.color = Color.red;
        foreach(EnemySpawn enemy in enemies) {
            Gizmos.DrawSphere(enemy.spawnPosition, 0.5f);
		}

        // Draw Collectable Spawn
        Gizmos.color = Color.yellow;
        foreach(CollectableSpawn c in collectables) {
            Gizmos.DrawSphere(c.spawnPosition, 0.5f);
		}

        // Draw connection points
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(leftAnchor, 0.5f);
        Gizmos.DrawSphere(rightAnchor, 0.5f);
        if(topAnchorAvailable) Gizmos.DrawSphere(toptionalAnchor, 0.5f);
        if(topAnchorAvailable) Gizmos.DrawSphere(botionalAnchor, 0.5f);
        
    }
}
