using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatBallScore : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField ]Transform scoreSpwanPoint;
    [SerializeField] GameObject scoreTxt;
    [SerializeField] Canvas canvas;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Movables"))
        {
            gameManager.AddToScoreMovable();
            collision.gameObject.GetComponent<Collider>().enabled = false;
            Instantiate(scoreTxt, scoreSpwanPoint.position, Quaternion.identity ,canvas.transform);
        }
    }

}
