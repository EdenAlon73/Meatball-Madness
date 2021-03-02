using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringLogic : MonoBehaviour
{
    [SerializeField]float springPower = 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = transform.up * springPower;
        }
    }
}
