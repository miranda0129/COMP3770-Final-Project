using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float timeToRotate = 1.0f;

    private float elapsedTime = 0.0f;
    public Vector3 eulerRotation;
    protected Quaternion targetRotation;
    protected Quaternion currentRotation;

    // Start is called before the first frame update
    public void Start()
    {
        currentRotation = transform.rotation;
        targetRotation = Quaternion.Euler(eulerRotation);
    }

    // Update is called once per frame
    public void Update()
    {
        elapsedTime += Time.deltaTime;


        transform.rotation = Quaternion.Lerp(currentRotation, currentRotation * targetRotation, (elapsedTime / timeToRotate));

        if(elapsedTime >= timeToRotate) {
            currentRotation = transform.rotation;
            elapsedTime = 0.0f;
        }
    }

    public void SetRotation(Vector3 eulerRotation) { targetRotation = Quaternion.Euler(eulerRotation); }
}
