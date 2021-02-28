using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private Transform ballSpawnPoint;
    private Animator animator;
    private ControlPoint controlPoint;
    [SerializeField] private GameObject meterHolder;
    [SerializeField] private Animator ballAnim;
    [SerializeField] private GameObject newMeatBall;
    private bool didShot = false;
    private CameraFollow cameraFollow;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        controlPoint = FindObjectOfType<ControlPoint>();
        cameraFollow = FindObjectOfType<CameraFollow>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsClosing", true);
            controlPoint.inCannon = true;
            Invoke("MeterOn", 1f);
        }
    }
    private void MeterOn()
    {
        cameraFollow.atCannon = true;
        meterHolder.SetActive(true);
        Invoke("ShootBall", 2.2f);
    }

    private void ShootBall()
    {
        if (!didShot)
        {
            newMeatBall.SetActive(true);
            
            didShot = true;
            
        }

    }
}
