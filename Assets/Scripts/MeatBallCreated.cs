using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatBallCreated : MonoBehaviour
{
    private ControlPoint controlPoint;
    private CameraFollow cameraFollow;
    private void Awake()
    {
        controlPoint = FindObjectOfType<ControlPoint>();
        cameraFollow = FindObjectOfType<CameraFollow>();
    }
    private void Start()
    {
        controlPoint.moveControllPoint = true;
        cameraFollow.speed = 2f;
        cameraFollow.atCannon = false;
    }
}
