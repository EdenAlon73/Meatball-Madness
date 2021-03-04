using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatBallScore : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField]private Transform scoreSpwanPoint;
    [SerializeField]private GameObject scoreTxt;
    [SerializeField]private Canvas canvas;
    private Animator anim;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Movables"))
        {
            gameManager.AddToScoreMovable();
            collision.gameObject.GetComponent<Collider>().enabled = false;
            Instantiate(scoreTxt, scoreSpwanPoint.position, Quaternion.identity ,canvas.transform);
        }
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            gameManager.AddToScoreMovable();
            Instantiate(scoreTxt, scoreSpwanPoint.position, Quaternion.identity, canvas.transform);
            Destroy(other.gameObject);
            
        }
    }
}
