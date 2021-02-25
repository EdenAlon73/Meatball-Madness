using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesLogic : MonoBehaviour
{
    private ControlPoint controlPoint;
    private void Awake()
    {
        controlPoint = FindObjectOfType<ControlPoint>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controlPoint.ConstraintsOff();
        }
    }
}
