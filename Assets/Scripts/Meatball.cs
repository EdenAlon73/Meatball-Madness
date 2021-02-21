using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meatball : MonoBehaviour
{
    private float xRot, yRot = 0f;
    public Rigidbody ballRb;
    public float rotationSpeed = 5f;
    public float lungeForce = 30f;

    private void Update()
    {
        transform.position = ballRb.position;
        if (xRot < -20)
        {
            xRot = -20;
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
        }

        

        if (Input.GetMouseButtonUp(0))
        {
            ballRb.velocity = transform.forward * lungeForce;
        }
    }
}
