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
            transform.Rotate(Vector3.right * (rotateSpeed * Time.deltaTime));
        }
        else
        {
            transform.Rotate(Vector3.right * (-rotateSpeed * Time.deltaTime));
        }
    }

    private void MoveHorizontally()
    {

    }

    private void MoveVertically()
    {

    }
}
