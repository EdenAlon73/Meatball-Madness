using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MeterFade : MonoBehaviour
{
    [SerializeField]private Image arrow;
    private Image self;
    [SerializeField]private float arrowAlphValue;
    private void Awake()
    {
        self = GetComponent<Image>();
    }
    private void Start()
    {
        arrowAlphValue = arrow.color.a;
    }
    private void Update()
    {
        var tmpColor = self.color;

        arrowAlphValue = arrow.color.a;
        tmpColor.a = arrowAlphValue;
        self.color = tmpColor;
    }
}
