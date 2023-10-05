using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndiaInk : MonoBehaviour
{
    [SerializeField] private GameObject squid;
    [SerializeField] private Image inkImage;

    private float time = 0f; 
    private float start = 1f;
    private float end = 0f;
    private float fadeTime = 3f;

    private void OnEnable() 
    {
        time = 0f;    
        Color color = inkImage.color;
    }

    private void Update()
    {
        Color color = inkImage.color;
        color.a = 1f;
        inkImage.color = color;

        //if (inkImage.color.a > 0) << else문이 정상적으로 작동하지 않아, 보류
        if (time <= 1f)
        {
            time += Time.deltaTime / fadeTime;
            color.a = Mathf.Lerp(start, end, time);

            inkImage.color = color;
        }   
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable() 
    {
        squid.GetComponent<Squid>().isTouched = false;
    }
}



// Fade.cs 꼭 되돌려놓기