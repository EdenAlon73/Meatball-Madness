using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private Transform ballSpawnPoint;
    private Animator animator;
    private ControlPoint controlPoint;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        controlPoint = FindObjectOfType<ControlPoint>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsClosing", true);
            controlPoint.inCannon = true;
        }
    }
    
}
