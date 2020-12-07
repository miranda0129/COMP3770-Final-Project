using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowCam : MonoBehaviour {
    public Transform target;
    private Vector3 endPos;
    private Vector3 startPos;

    public float smoothTime = 0.3f;
    private float elapsedTime = 0.0f;
    public float cameraHeight = 0;


    void Start() {
        init();
    }

    // Use fixed update because we are following an object affected by physics: 
    // (Late Update will cause jittery behaviour since multiple fixed update frames will have completed while late update only once.)
    void FixedUpdate() {

        // refind the player on player death.
        if(target == null) {
            target = GameObject.Find("Player").transform;
            init();
        }

        elapsedTime += Time.deltaTime;

        transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / smoothTime));

        if(Vector3.Distance(transform.position, endPos) <= 0.1f || elapsedTime >= smoothTime) {
            startPos = transform.position;
            Vector3 desiredPosition = target.TransformPoint(new Vector3(0, cameraHeight, -10));
            endPos = new Vector3(Mathf.Clamp(desiredPosition.x, startPos.x, startPos.x + 10), desiredPosition.y, desiredPosition.z);
            elapsedTime = 0.0f;
        }
    }

    void init() {
        endPos = target.TransformPoint(new Vector3(0, cameraHeight, -10));
        transform.position = endPos;
        startPos = transform.position;
        elapsedTime = 0;

    }
}
