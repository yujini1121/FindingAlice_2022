using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFixed : MonoBehaviour
{

    [SerializeField] float setWidth;       // 사용자 설정(Canvas Scaler) 너비
    [SerializeField] float setHeight;      // 사용자 설정(Canvas Scaler) 높이
    [SerializeField] float deviceWidth;      // 기기 너비 저장
    [SerializeField] float deviceHeight;     // 기기 높이 저장

    [SerializeField] float thisImageWidth;   // 해당 이미지 너비
    [SerializeField] float thisImageHeight;  // 해당 이미지 높이

    void Awake()
    {
        GameObject canvas = GameObject.Find("Canvas");

        setWidth = canvas.gameObject.GetComponent<CanvasScaler>().referenceResolution.x;
        setHeight = canvas.gameObject.GetComponent<CanvasScaler>().referenceResolution.y;
        deviceWidth = Screen.width;
        deviceHeight = Screen.height;
        thisImageWidth = this.transform.gameObject.GetComponent<RectTransform>().sizeDelta.x;
        thisImageHeight = this.transform.gameObject.GetComponent<RectTransform>().sizeDelta.y;
    }

    void OnEnable()
    {
        SetResolution();
    }

    public void SetResolution()
    {
        float currentAspectRatio = deviceWidth / deviceHeight;
        float fixedAspectRatio = setWidth / setHeight;
        float thisAspectRatio = thisImageWidth / thisImageHeight;

        if (thisAspectRatio > currentAspectRatio) // 정해진 사이즈보다 클 경우
        {
            this.transform.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(
                (int)(thisImageWidth * (1.0 + fixedAspectRatio * 0.1)),
                (int)(thisImageHeight * (1.0 + fixedAspectRatio * 0.1)));
        }
        else if (thisAspectRatio < currentAspectRatio) // 
        {
            this.transform.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(
                (int)(thisImageWidth * (1.0 - fixedAspectRatio * 0.1)),
                (int)(thisImageHeight * (1.0 - fixedAspectRatio * 0.1)));
        }
    }
}