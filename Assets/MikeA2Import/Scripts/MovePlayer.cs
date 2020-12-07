using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
     private float speed = 30.0f;
     private float jumpForce = 25.0f;
     private Rigidbody rbody;

     private bool isGrounded = false;
     private bool mLeft, mRight, mForward, mBack, jump;
     public bool isSafe = false;


     void Awake()
     {
          rbody = gameObject.GetComponent<Rigidbody>();
     }

    // Update is called once per frame
     void Update()
     {

          // Movement input - will apply force in any direction where the key is currently being pressed (continuous)
          if (Input.GetKey(KeyCode.W))  mForward = true;
          else                          mForward = false;

          if (Input.GetKey(KeyCode.D))  mRight = true;
          else                          mRight = false;

          if (Input.GetKey(KeyCode.S))  mBack = true;
          else                          mBack = false;

          if (Input.GetKey(KeyCode.A))  mLeft = true;
          else                          mLeft = false;

          // Jump input - can only jump if touching the ground (not continuous)
          if (Input.GetKey(KeyCode.Space) && isGrounded) jump = true;
          else jump = false;

     }

     void FixedUpdate(){
          
          // Apply movement force
          if(mForward)   rbody.AddForce(Vector3.forward * speed);
          if(mRight)     rbody.AddForce(Vector3.right * speed);
          if(mBack)      rbody.AddForce(Vector3.back * speed);
          if(mLeft)      rbody.AddForce(Vector3.left * speed);
          
          // Apply jump force
          if (jump) {

               rbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
               isGrounded = false;

          }
     }
     
     
     void OnCollisionEnter(Collision col) {

          isGrounded = true;
     }
}
