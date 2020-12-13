using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{

     public float timer = 1.0f;

     private float elapsedTime = 0.0f;
     public Vector3 eulerRotation;
     private Quaternion targetRotation;
     private Quaternion currentRotation;

    // Start is called before the first frame update
    void Start()
    {
          currentRotation = transform.rotation;
          targetRotation = Quaternion.Euler(eulerRotation);
    }

    // Update is called once per frame
    void Update()
    {
          elapsedTime += Time.deltaTime;


          transform.rotation = Quaternion.Lerp(currentRotation, currentRotation * targetRotation, (elapsedTime / timer));

          if (elapsedTime >= timer) {
               currentRotation = transform.rotation;
               elapsedTime = 0.0f;
          }
     }
}
