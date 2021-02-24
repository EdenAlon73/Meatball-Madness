using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class Meatball : MonoBehaviour
{
    private float xRot, yRot = 0f;
    public Rigidbody ballRb;
    public float rotationSpeed = 5f;
    public float lungeForce = 30f;
    public LineRenderer line;
    float distToGround;
    [SerializeField] Collider collider;
    [SerializeField] GameObject stain;
    bool didDrawStain = false;
    [SerializeField] float pressedTime;
    [SerializeField] float cooldownTime;
    [SerializeField] float lineAnimeDuraition = 5f;
    bool constraintsOn = false;
    public bool inCannon = false;
    bool finishedPrep = false;
    [SerializeField]private Transform ballPointCannon;
    [SerializeField] GameObject meatBallSelf;
    private void Start()
    {
        distToGround = collider.bounds.extents.y;

    }
    private void Update()
    {

        transform.position = ballRb.position;
        if (!inCannon)
        {
            if (!didDrawStain && isgrounded())
            {
                //Instantiate(stain, stainPos, Quaternion.identity);
            }

            if (xRot < -18)
            {
                xRot = -18;
            }

            if (xRot > 20)
            {
                xRot = 20;
            }

            if (yRot > 12)
            {
                yRot = 12;
            }

            if (yRot < -12)
            {
                yRot = -12;
            }

            if (Input.GetMouseButton(0))
            {
                pressedTime += Time.deltaTime;
                if (!constraintsOn)
                {
                    ballRb.constraints = RigidbodyConstraints.FreezePosition;
                    constraintsOn = true;
                }
                // xRot += Input.GetAxis("Mouse Y") * rotationSpeed;
                yRot += Input.GetAxis("Mouse X") * rotationSpeed;
                transform.rotation = Quaternion.Euler(xRot, yRot, 0f);
                line.gameObject.SetActive(true);


                StartCoroutine(DrawLine());

            }

            if (Input.GetMouseButtonUp(0))
            {
                constraintsOn = false;
                line.gameObject.SetActive(false);
                if (pressedTime >= cooldownTime)
                {
                    ballRb.constraints = RigidbodyConstraints.None;
                    ballRb.velocity = transform.forward * lungeForce;

                    pressedTime = 0;
                }
                else
                {
                    print("time is a bitch");
                    ballRb.constraints = RigidbodyConstraints.None;
                    pressedTime = 0;
                }
            }
        }
        else
        {
            if (!finishedPrep)
            {
                
                //finishedPrep = true;
                meatBallSelf.transform.position = Vector3.MoveTowards(meatBallSelf.transform.position, ballPointCannon.position, 15);
                ballRb.velocity = Vector3.zero;
            }
            if (Input.GetMouseButtonUp(0))
            {
                ballRb.constraints = RigidbodyConstraints.None;
            }
        }
    }



    private bool isgrounded()
    {
        return  Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
    
    private IEnumerator DrawLine()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + transform.forward * 10f);
        float startLineTime = Time.time;
        Vector3 starPos = line.GetPosition(0);
        Vector3 endPos = line.GetPosition(1);

        Vector3 pos = starPos;

        while(pos != endPos)
        {
            float t = (Time.time - startLineTime) / lineAnimeDuraition;
            pos = Vector3.Lerp(starPos, endPos, t);
            line.SetPosition(1, pos);
            yield return null;
        }
    }



    public void ConstraintsOff()
    {
        ballRb.constraints = RigidbodyConstraints.None;
    }
}
