using System;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 50f;
    public float jumpForce  = 450f;
    public float maxSpeed = 50f;
    public float maxFallSpeed = 450f;

    //Say gex
      Rigidbody rb;
      void Start()
    {
           rb = GetComponent<Rigidbody>();
    }
      void Update()
    {
        Movement();
        Jump();
    }
    void FixedUpdate()
    {
        MaxMovement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * Time.fixedDeltaTime * movementSpeed , ForceMode.Impulse) ;
           
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * Time.fixedDeltaTime * movementSpeed , ForceMode.Impulse);
        }
        
    }
     void Jump()
 {  
      {
        bool grounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * Time.fixedDeltaTime * jumpForce, ForceMode.Impulse);
        }
      }  
 }
          void MaxMovement()
    {
        if(rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }
        if(rb.linearVelocity.magnitude > maxFallSpeed)
        {
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxFallSpeed);
        }
    }
    
    //Cat sex
        


}
