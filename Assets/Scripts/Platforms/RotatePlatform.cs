using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Platform))]
public class RotatePlatform : MonoBehaviour
{
    private Platform platform;
    public float timeToRotate = 1.0f;

    private float elapsedTime = 0.0f;
    public Vector3 eulerRotation;
    private Quaternion targetRotation;
    private Quaternion currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        currentRotation = transform.rotation;
        targetRotation = Quaternion.Euler(eulerRotation);

        platform = gameObject.GetComponent<Platform>();

        // Slide the prefab over so that it is centered around the rotating pivot.
        Vector3 rightAnchor = platform.GetRightAnchor();

        transform.position = rightAnchor;

        rightAnchor.x += platform.GetWidth();
        platform.SetRightAnchor(rightAnchor);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;


        transform.rotation = Quaternion.Lerp(currentRotation, currentRotation * targetRotation, (elapsedTime / timeToRotate));

        if (elapsedTime >= timeToRotate) {
            currentRotation = transform.rotation;
            elapsedTime = 0.0f;
        }
    }
}
