using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllPointLogic : MonoBehaviour
{
    float xRotation = 0f;
    float yRotation = 0f;
    [SerializeField]Rigidbody ball_Rb;
    [SerializeField] float rotationSpeed;
    [SerializeField] float shotPower = 30f;
    private void Awake()
    {
      //  ball_Rb = GetComponentInParent<Rigidbody>();
    }
    private void Update()
    {
        transform.position = ball_Rb.position;
        if (Input.GetMouseButton(0))
        {
            xRotation += Input.GetAxis("Mouse X") * rotationSpeed;
            yRotation += Input.GetAxis("Mouse Y") * rotationSpeed;
            transform.rotation = Quaternion.Euler(yRotation, xRotation, 0);
            if(yRotation < -35f)
            {
                yRotation = -35f;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            ball_Rb.velocity = transform.forward * shotPower;
        }
    }
}
