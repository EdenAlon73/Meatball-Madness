using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 15f;
    [SerializeField] private float SpeedForPress = 30;
    [SerializeField] private Transform target2ndPoint;
    Transform targetOgPoint;
    private float ogSpeed;
    
    

    public Transform obstruction;
    private float zoomSpeed = 2f;

    private void Start()
    {
        obstruction = target;
        targetOgPoint = target;
        ogSpeed = speed;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, speed * Time.deltaTime);
        CameraPressControll();
    }

    private void CameraPressControll()
    {
        if (Input.GetMouseButton(0))
        {
            target = target2ndPoint;
            speed = SpeedForPress;
        }
        if (Input.GetMouseButtonUp(0))
        {
            target = targetOgPoint;
            speed = ogSpeed;
        }
    }
    private void LateUpdate()
    {
      //  CamSeeThrough();
    }

    private void CamSeeThrough()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, target.position - transform.position, out hit, 4.5f))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                obstruction = hit.transform;
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode =
                    UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                if (Vector3.Distance(obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, target.position) >= 1.5f)
                {
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                }
            }
            else
            {
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode =
                    UnityEngine.Rendering.ShadowCastingMode.On;
                if (Vector3.Distance(transform.position, target.position) < 4.5f)
                {
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                }
            }
        }
    }
}
