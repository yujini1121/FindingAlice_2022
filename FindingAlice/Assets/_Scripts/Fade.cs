﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    //페이드 인, 아웃
    // 페이드 인 아웃시 이미지 알파값 조정
    // 코루틴
    private Image fadeImage;
    private float time, fadeTime, start, end;

    public bool check;
    private bool firstTime;

    private void Init()
    {
        fadeImage = GetComponent<Image>();
        time = 0;
        fadeTime = 1;
        start = 0;
        end = 1;
        firstTime = true;
    }
    
    private void Awake()
    {
        Init();
        StopCoroutine(FadeInFlow());
        StartCoroutine(FadeInFlow());
    }

    private void OnEnable()
    {
        if (!firstTime)
        {
            StopCoroutine(FadeOutFlow());
            StartCoroutine(FadeOutFlow());
        }
    }    

    private IEnumerator FadeOutFlow()
    {
        time = 0;
        Color color = fadeImage.color;
        while(color.a < end)
        {
            time += Time.deltaTime / fadeTime;
            color.a = Mathf.Lerp(start, end, time);
            fadeImage.color = color;
            yield return null;
        }
        check = true;

        yield return null;
    }

    private IEnumerator FadeInFlow()
    {
        time = 0;
        Color color = fadeImage.color;

        while(color.a > start)
        {
            time += Time.deltaTime / fadeTime;
            color.a = Mathf.Lerp(end, start, time);
            fadeImage.color = color;
            yield return null;
        }
        this.gameObject.SetActive(false);
        firstTime = false;

        yield return null;
    }
}
