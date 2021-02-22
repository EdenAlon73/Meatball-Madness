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
    float distToGround;
    [SerializeField] Collider collider;
    private void Start()
    {
        distToGround = collider.bounds.extents.y;
    }
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
            transform.rotation = Quaternion.Euler(xRot, yRot, 0f);
            line.gameObject.SetActive(true);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + transform.forward * 10f);
        }
        
        if (Input.GetMouseButtonUp(0) && isgrounded())
        {
            
            
            ballRb.velocity = transform.forward * lungeForce;
            line.gameObject.SetActive(false);
               
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Touch");
        if (other.gameObject.CompareTag("Ground"))
        {
            print("");
            //isGrounded = true;
        }
    }

    private bool isgrounded()
    {
        return  Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

}
