using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringLogic : MonoBehaviour
{
    [SerializeField]float springPower = 100f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print(gameObject.tag);
            collision.gameObject.GetComponent<Rigidbody>().velocity = transform.up * springPower;
        }
    }
}
