using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowCam : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    public float cameraHeight = 0;

    private Vector3 previousPosition;

    void LateUpdate() {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, cameraHeight, -10));
        Vector3 desiredPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = new Vector3(Mathf.Clamp(desiredPosition.x, previousPosition.x, targetPosition.x + 20f), desiredPosition.y, desiredPosition.z);
        previousPosition = transform.position;
    }

}
