using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowCam : MonoBehaviour {
    public Transform target;
    private Vector3 endPos;
    private Vector3 startPos;
    public float timebeforeUpdate = 0.3f;
    private float smoothMultiplier = 1.0f;
    private float smoothTime = 0.3f;
    private float elapsedTime = 0.0f;
    public float cameraHeight = 0;
    public float cameraOffsetX = 0;

    public bool normalSpeed = true;
    public bool willUpdate = true;

    void Start() {
        
    }

    // Use fixed update because we are following an object affected by physics: 
    // (Late Update will cause jittery behaviour since multiple fixed update frames will have completed while late update only once.)
    void FixedUpdate() {

        if(willUpdate) {

            elapsedTime += Time.deltaTime;

            smoothTime = elapsedTime / (timebeforeUpdate / smoothMultiplier);
            transform.position = Vector3.Lerp(startPos, endPos, smoothTime);

            // if we are close to the end position
            if(Vector3.Distance(transform.position, endPos) <= 0.1f || elapsedTime >= smoothTime) {
                startPos = transform.position;
                Vector3 desiredPosition = target.TransformPoint(new Vector3(0, cameraHeight, 0));
                endPos = new Vector3(Mathf.Clamp(desiredPosition.x, startPos.x, Mathf.Infinity), desiredPosition.y, -10);


                // Speed up camera at different thresholds.
                float distance = Vector3.Distance(startPos, endPos);

                if(!normalSpeed) {

                    if(distance <= 1.0f) {
                        normalSpeed = true;
                        NormalSpeed();
                    }

                } else if(distance >= 5.0f) {
                    normalSpeed = false;
                    FastSpeed();
                }

                elapsedTime = 0.0f;
            }
        }
    }

    void init() {
        elapsedTime = 0;
        endPos = target.TransformPoint(new Vector3(9.6f, cameraHeight, -10));
        transform.position = endPos;
        startPos = transform.position;

    }

    void NormalSpeed() {
        smoothMultiplier = 1.0f;
    }

    void FastSpeed() {
        smoothMultiplier = 2.0f;
    }

    public void SetTarget(Transform newTarget) {
        target = newTarget;
        init();
	}
}
