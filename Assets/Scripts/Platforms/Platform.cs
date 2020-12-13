using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{


    [Header("Spawn Location")]
    public Vector3 spawnPoint;          // Relative position of the spawn point.
    private Vector3 spawnPosition;      // world position of the spawn point.   (needed so we aren't constantly transforming the point out of position)
    public bool hasSpawnedSomething = false;
    public bool canSpawnAdd = true;

    [Header("Attachment Points")]
    public Vector3 leftAnchor;
    public Vector3 rightAnchor;
    [Tooltip("For use with Moving Platform - false = default: anchors are set by moving platform. true = waypoints on moving platform are positioned by anchors.")]
    public bool moveWaypointToAnchor = false;

    [Tooltip("How wide is the physical platform?")]
    public float width = 1;
    public float height = 1;

    public Renderer platformRenderer;
    public Renderer optionalRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.TransformPoint(spawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLeftAnchor(Vector3 left) { leftAnchor = left; }
    public Vector3 GetLeftAnchor() { return leftAnchor; }
    public void SetRightAnchor(Vector3 right) { rightAnchor = right; }
    public Vector3 GetRightAnchor() { return rightAnchor; }
    public float GetWidth() { return width; }
    public float GetHeight() { return height; }

    public Vector3 CalculateBottomAnchor() {
        return new Vector3(GetRightAnchor().x - (width / 2), GetLeftAnchor().y - height, 0);
	}

    public Vector3 GetSpawnPoint() {
        spawnPosition = transform.TransformPoint(spawnPoint);
        return spawnPosition; 
    }

    public Vector3 GetCenterPoint() {
        return ((leftAnchor + rightAnchor) / 2.0f);
	}

    void OnDrawGizmosSelected() {

        // Draw Player Spawn
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(GetSpawnPoint(), 0.5f);

        // Draw connection points
        Gizmos.color = Color.cyan;

        if(gameObject.GetComponent<MovingPlatform>()) {

            Gizmos.DrawSphere((leftAnchor), 0.2f);
            Gizmos.DrawSphere((rightAnchor), 0.2f);

        } else if(gameObject.GetComponent<RotatePlatform>()) {

            Vector3 positionBeforeMoving = leftAnchor;
            positionBeforeMoving.x -= width;
            Gizmos.DrawSphere(transform.TransformPoint(positionBeforeMoving), 0.2f);
            Gizmos.DrawSphere(transform.TransformPoint(rightAnchor), 0.2f);
        } else {
            Gizmos.DrawSphere(transform.TransformPoint(leftAnchor), 0.2f);
            Gizmos.DrawSphere(transform.TransformPoint(rightAnchor), 0.2f);
        }
        
    }

	private void OnValidate() {
        spawnPosition = transform.TransformPoint(spawnPoint);
	}
}
