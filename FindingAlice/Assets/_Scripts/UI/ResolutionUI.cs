using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionUI : MonoBehaviour
{
    RectTransform rt;
    float canvasScalar;
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);
    }
}
