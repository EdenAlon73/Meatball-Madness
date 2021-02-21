using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class ChangeFace : MonoBehaviour
{
  private MeshRenderer meshRenderer;
  [SerializeField] private int currentFaceID;
  [SerializeField] private int randomFaceID;
  [SerializeField] private Material[] differentFaces;

  private void Awake()
  {
    meshRenderer = GetComponent<MeshRenderer>();
  }

  private void Update()
  {
    CalculateNewFace();
    SwitchFace();
  }

  private void SwitchFace()
  {
    if (currentFaceID == 0)
    {
      meshRenderer.material = differentFaces[0];
    }
    else if (currentFaceID == 1)
    {
      meshRenderer.material = differentFaces[1];
    }
    else if (currentFaceID == 2)
    {
      meshRenderer.material = differentFaces[2];
    }
    else if (currentFaceID == 3)
    {
      meshRenderer.material = differentFaces[3];
    }
    
  }

  private void CalculateNewFace()
  {
    if (Input.GetMouseButton(0))
    {
      randomFaceID = Random.Range(0, 3);
      currentFaceID = randomFaceID;
    }
    
    
  }
}
