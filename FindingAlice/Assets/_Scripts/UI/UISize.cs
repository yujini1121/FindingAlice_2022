using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISize : MonoBehaviour
{
    RectTransform rt;
    void Awake()
    {
        rt = GetComponent<RectTransform>();
        rt.rect.Set(rt.rect.x, rt.rect.y, Screen.currentResolution.width, this.rt.rect.height);
    }

    //void Update()
    //{
    //    
    //}
}
