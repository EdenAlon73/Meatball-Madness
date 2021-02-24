using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    Transform ballSpawnPoint;
    Animator anim;
    [SerializeField]Meatball meatball;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            meatball.inCannon = true;
            Invoke("StartCannon", 1f);
        }
    }

    private void StartCannon()
    {
        anim.SetBool("BallEnterd", true);
    } 
}
