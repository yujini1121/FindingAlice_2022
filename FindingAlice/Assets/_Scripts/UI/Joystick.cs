using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [Header("Value")]
    //조이스틱 레버 반경
    [SerializeField] float radius = 250f;

    RectTransform lever;
    //레버의 초기 위치 저장 벡터
    Vector3 lever_original_transform;
    //마우스 위치 저장 벡터
    Vector3 MousePos2D;
    //조이스틱과 중점의 간격 저장 벡터
    Vector3 length;
    //조이스틱의 그립여부 판단
    bool touchFlag;

    void Start() {
        lever = GetComponent<RectTransform>();
        lever_original_transform = lever.position;
    }

    void Update() {
        //조이스틱을 눌렀을 때 PlayerMovement의 Move함수 호출
        if (touchFlag)
        {
            // GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().Move(lever.anchoredPosition.x);
            GameObject.FindWithTag("Player").SendMessage("Move", lever.anchoredPosition.x);
            //Debug.Log(lever.anchoredPosition.x);
        }
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        touchFlag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        MousePos2D = Input.mousePosition;

        //레버의 위치 제한
        length = MousePos2D - lever_original_transform;
        if (length.magnitude > radius)
        {
            length.Normalize();
            length *= radius;
        }
        //터치 위치로 레버 이동
        lever.position = lever_original_transform + length;
    }

    //레버의 위치 초기화
    public void OnPointerUp(PointerEventData eventData)
    {
        touchFlag = false;
        lever.position = lever_original_transform;
    }
}