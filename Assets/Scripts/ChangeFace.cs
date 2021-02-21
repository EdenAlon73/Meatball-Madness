using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class ChangeFace : MonoBehaviour
{
  private MeshRenderer meshRenderer;
  [SerializeField] private int currentFaceID;
  [SerializeField] private Material[] differentFaces;
  int excludeLastRandNum;
  bool firstRun = true;

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
    if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
    {
      currentFaceID = RandomWithExclusion(0, 4);
      
    }
  }
  
  int RandomWithExclusion(int min, int max)
  {
    int result;
    //Don't exclude if this is first run.
    if (firstRun)
    {
      //Generate normal random number
      result = UnityEngine.Random.Range(min, max);
      excludeLastRandNum = result;
      firstRun = false;
      return result;
      
    }

    //Not first run, exclude last random number with -1 on the max
    result = UnityEngine.Random.Range(min, max - 1);
    //Apply +1 to the result to cancel out that -1 depending on the if statement
    result = (result < excludeLastRandNum) ? result : result + 1;
    excludeLastRandNum = result;
    return result;
  }
}
