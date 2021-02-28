using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMaster : MonoBehaviour
{
    [SerializeField] private bool doIrotate = false;
    [SerializeField] private bool doImoveHorizontally = false;
    [SerializeField] private bool doImoveVertically = false;
    [SerializeField] private float rotateSpeed = 15f;
    [SerializeField] private bool doIrotateLeft = false;
    [SerializeField] private float moveSpeed = 20f;
    private bool dirRight = true;
    [SerializeField] private float horizDist = 5f;
    private float posXog;
    private float posYog;
    private bool dirUp = true;
    private float verticalDist = 5f;
    private void Start()
    {
        posXog = transform.position.x;
        posYog = transform.position.y;
    }
    private void Update()
    {
        if (doIrotate)
        {
            Rotate();
        }

        if (doImoveHorizontally)
        {
            MoveHorizontally();
        }

        if (doImoveVertically)
        {
            MoveVertically();
        }
    }

    private void Rotate()
    {
        if (!doIrotateLeft)
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
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
        }

        if(transform.position.x >= posXog + horizDist)
        {
            dirRight = false;
        }
        if(transform.position.x <= posXog - horizDist)
        {
            dirRight = true; 
        }

    }

    private void MoveVertically()
    {
        if (dirUp)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.up * moveSpeed * Time.deltaTime);
        }

        if (transform.position.y >= posYog + verticalDist)
        {
            dirUp = false;
        }
        if (transform.position.y <= posYog - verticalDist)
        {
            dirUp = true;
        }
    }
}
