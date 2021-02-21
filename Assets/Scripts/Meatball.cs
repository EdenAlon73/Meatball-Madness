using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class Meatball : MonoBehaviour
{
    private float xRot, yRot = 0f;
    public Rigidbody ballRb;
    public float rotationSpeed = 5f;
    public float lungeForce = 30f;
    public LineRenderer line;
    bool isGrounded = true;
    
    private void Update()
    {
        transform.position = ballRb.position;
        
        if (xRot < -18)
        {
            xRot = -18;
        }

        if (xRot > 20)
        {
            xRot = 20;
        }

        if (Input.GetMouseButton(0))
        {
            
            xRot += Input.GetAxis("Mouse Y") * rotationSpeed;
            yRot += Input.GetAxis("Mouse X") * rotationSpeed;
            transform.rotation = Quaternion.Euler(xRot,yRot, 0f);
            line.gameObject.SetActive(true);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + transform.forward * 10f);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            //if (isGrounded)
            {
                ballRb.velocity = transform.forward * lungeForce;
                line.gameObject.SetActive(false);
                isGrounded = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }


}
