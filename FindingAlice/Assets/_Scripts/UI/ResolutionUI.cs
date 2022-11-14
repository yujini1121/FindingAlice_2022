using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionUI : MonoBehaviour
{
    int width, height;
    [SerializeField]GameObject textTest;
    void Awake()
    {
        width = Screen.currentResolution.width;
        height = Screen.currentResolution.height;
        //rt = GetComponent<RectTransform>();
        textTest.GetComponent<Text>().text = $"width : {width} \nheight : {height}";
        Screen.SetResolution(Screen.width, Screen.height, true);
    }
}
