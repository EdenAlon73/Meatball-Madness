﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class ControlPoint : MonoBehaviour
{
     // Movement
    private float xRot, yRot = 0f;
    public Rigidbody ballRb;
    public float rotationSpeed = 5f;
    public float lungeForce = 30f;
    private float distToGround;
    bool constraintsOn = false;
    public bool inCannon = false;
    [SerializeField] private float pressedTime;
    [SerializeField] private float cooldownTime;
    private RigidbodyConstraints ogRbConstraints;
    

    //Line
    public LineRenderer line;
    private bool didDrawStain = false;
    [SerializeField] private float lineAnimeDuraition = 5f;
    
    // HyperSpeed Particles
    private GameObject particleHyperSpeed;
    private bool hyperSpeedParticlesActive = false;

    //Cache Ref
    [SerializeField] private Collider collider;
    [SerializeField] private GameObject stain;
    [SerializeField] private Transform ballPointCannon;
    [SerializeField] private GameObject meatBallSelf;
    [SerializeField] private GameObject cannonMeatBall;
    


    public bool moveControllPoint = false;
    private bool finishedPrep = false;
    
    /// <summary>
    /// /////////////////////////////////////////////////
    /// </summary>
    
    private void Start()
    {
        distToGround = collider.bounds.extents.y;
        particleHyperSpeed = GameObject.FindWithTag("Particle_HyperSpeed");
        particleHyperSpeed.SetActive(false);
        ogRbConstraints = ballRb.constraints;
    }
    private void Update()
    {
        if (!inCannon)
        {
            transform.position = ballRb.position;
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

            if (yRot > 20)
            {
                yRot = 20;
            }

            if (yRot < -20)
            {
                yRot = -20;
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
                    BackToOgConstraints();
                    ballRb.velocity = transform.forward * lungeForce;

                    pressedTime = 0;
                }
                else
                {
                    BackToOgConstraints();
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
                BackToOgConstraints();
            }
        }
        
        if (moveControllPoint)
        {
            transform.position = cannonMeatBall.transform.position;
           
        }

        if (ballRb.velocity.z >= 20f)
        {
            hyperSpeedParticlesActive = true;
            particleHyperSpeed.SetActive(true);
        }
        else
        {
            DisableHyperSpeedParticle();
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



    public void BackToOgConstraints()
    {
        ballRb.constraints = ogRbConstraints;
    }

    private void DisableHyperSpeedParticle()
    {
        particleHyperSpeed.SetActive(false);
        hyperSpeedParticlesActive = false;
    }
 
    
}
