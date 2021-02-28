using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMaster : MonoBehaviour
{
    [Header("Rotation Config")]
    [SerializeField] private bool doIRotate = false;
    [SerializeField] private bool doIRotateLeft = false;
    [SerializeField] private float rotateSpeed = 15f;
    
    [Header("Horizontal Movement Config")]
    [SerializeField] private bool doIMoveHorizontally = false;
    [SerializeField] private float horizDistance = 5f;
    [SerializeField] private float horizMoveSpeed = 20f;
    
    [Header("Vertical Movement Config")]
    [SerializeField] private bool doIMoveVertically = false;
    [SerializeField] private float verticalDistance = 5f;
    [SerializeField] private float verticalMoveSpeed = 20f;
    
    // Internal Bools & Floats
    private float posXog;
    private float posYog;
    private bool dirRight = true;
    private bool dirUp = true;
    
    private void Start()
    {
        posXog = transform.position.x;
        posYog = transform.position.y;
    }
    private void Update()
    {
        if (doIRotate)
        {
            Rotate();
        }

        if (doIMoveHorizontally)
        {
            MoveHorizontally();
        }

        if (doIMoveVertically)
        {
            MoveVertically();
        }
    }

    private void Rotate()
    {
        if (!doIRotateLeft)
        {
            transform.Rotate(Vector3.up * (rotateSpeed * Time.deltaTime));
        }
        else
        {
            transform.Rotate(Vector3.up * (-rotateSpeed * Time.deltaTime));
        }
    }

    private void MoveHorizontally()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.right * (horizMoveSpeed * Time.deltaTime));
        }
        else
        {
            transform.Translate(-Vector2.right * (horizMoveSpeed * Time.deltaTime));
        }

        if(transform.position.x >= posXog + horizDistance)
        {
            dirRight = false;
        }
        if(transform.position.x <= posXog - horizDistance)
        {
            dirRight = true; 
        }

    }

    private void MoveVertically()
    {
        if (dirUp)
        {
            transform.Translate(Vector2.up * (verticalMoveSpeed * Time.deltaTime));
        }
        else
        {
            transform.Translate(-Vector2.up * (verticalMoveSpeed * Time.deltaTime));
        }

        if (transform.position.y >= posYog + verticalDistance)
        {
            dirUp = false;
        }
        if (transform.position.y <= posYog - verticalDistance)
        {
            dirUp = true;
        }
    }
}
