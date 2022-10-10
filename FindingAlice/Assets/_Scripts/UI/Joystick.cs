using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

#if UNITY_ANDROID
public class Joystick : MonoBehaviour
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
    GameObject player;

    public static int joystickId = -1, clockId = -1, jumpId = -1;
    [SerializeField] RectTransform jsAreaRect;

    bool checkJump = false;

    private void Awake()
    {
        Input.multiTouchEnabled = true;
    }
    void Start()
    {
        lever = GetComponent<RectTransform>();
        lever_original_transform = lever.position;
        jsAreaRect = GetComponentInParent<RectTransform>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                if (joystickId == -1 && CheckRect(jsAreaRect, t.position))
                    joystickId = Input.GetTouch(i).fingerId;
                if (jumpId == -1 && checkJump)
                    jumpId = Input.GetTouch(i).fingerId;
                else if (clockId == -1 && t.position.x > Screen.width / 2)
                    clockId = Input.GetTouch(i).fingerId;

            }
            if (t.phase == TouchPhase.Ended)
            {
                if (i == joystickId)
                    joystickId = -1;
                if (i == jumpId)
                    jumpId = -1;
                if (i == clockId)
                    clockId = -1;
            }
        }
        //조이스틱을 눌렀을 때 PlayerMovement의 Move함수 호출
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).fingerId == joystickId)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Stationary || Input.GetTouch(i).phase == TouchPhase.Moved)
                {
                    if (!(Vector2.Dot(lever.anchoredPosition.normalized, lever.up) > 0.9f) &&
                        !(Vector2.Dot(lever.anchoredPosition.normalized, lever.up) < -0.9f))
                    {
                        player.SendMessage("Move", lever.anchoredPosition.x);
                    }
                    else player.GetComponent<PlayerMovement>().AnimControl("isWalk", false);

                    MousePos2D = Input.GetTouch(i).position;

                    //레버의 위치 제한
                    length = MousePos2D - lever_original_transform;
                    if (length.magnitude > radius)
                    {
                        length = length.normalized * radius;
                    }
                    //터치 위치로 레버 이동
                    lever.position = lever_original_transform + length;
                }
            }   
        }
        if (joystickId == -1)
        {
                //레버의 위치 초기화
            player.GetComponent<PlayerMovement>().AnimControl("isWalk", false);
            lever.position = lever_original_transform;
        }
    }


    public void JumpBtn(bool b)
    {
        checkJump = b;
    }

    private bool CheckRect(RectTransform rt, Vector2 touchPos)
    {
        float posX = rt.localPosition.x * rt.lossyScale.x;
        float posY = rt.localPosition.y * rt.lossyScale.y;
        return (touchPos.x > (rt.transform.position.x - posX)) &&
            (touchPos.x < (rt.transform.position.x + posX)) &&
            (touchPos.y > (rt.transform.position.y - posY)) &&
            (touchPos.y < (rt.transform.position.y + posY));
    }
}

#elif UNITY_EDITOR_WIN
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

    void Update()
    {
        //조이스틱을 눌렀을 때 PlayerMovement의 Move함수 호출
        if (touchFlag)
        {
            if (!(Vector2.Dot(lever.anchoredPosition.normalized, lever.up) > 0.9f) &&
                !(Vector2.Dot(lever.anchoredPosition.normalized, lever.up) < -0.9f))
            {
                GameObject.FindWithTag("Player").SendMessage("Move", lever.anchoredPosition.x);
            }
            else GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().AnimControl("isWalk", false);
        }
        else
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().AnimControl("isWalk", false);
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
            length = length.normalized * radius;
        }
        //터치 위치로 레버 이동
        lever.position = lever_original_transform + length;
        //GameObject.FindWithTag("Player").SendMessage("Move", lever.anchoredPosition.x);
    }

    //레버의 위치 초기화
    public void OnPointerUp(PointerEventData eventData)
    {
        touchFlag = false;
        lever.position = lever_original_transform;
    }
}
#endif