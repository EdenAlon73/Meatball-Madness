using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesLogic : MonoBehaviour
{
    private Meatball meatball;
    private void Awake()
    {
        meatball = FindObjectOfType<Meatball>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            meatball.ConstraintsOff();
        }
    }
}
