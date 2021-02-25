using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private Transform ballSpawnPoint;
    private Animator animator;
    [SerializeField] private Meatball meatballControlPoint;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsClosing", true);
            meatballControlPoint.inCannon = true;
            
        }
    }
    
}
