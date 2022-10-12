using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] private GameObject followTarget;
    PlayerMovement playerMove;
    Transform playerTrans;
    Vector3 targetPosition;
    RectTransform joystickPos;
    bool joystickUpNDown = false;
    float joystickUpNDownStartTime;

#if false
    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerTrans = GameObject.Find("Player").transform;
        followTarget = playerTrans.Find("Clock").gameObject;
        joystickPos = GameObject.Find("Joystick").transform.GetChild(0).gameObject.GetComponent<RectTransform>();
    }
#else
    void Awake()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerTrans = GameObject.Find("Player").transform;
        targetPosition = playerTrans.position;
        followTarget = playerTrans.Find("Clock").gameObject;
        joystickPos = GameObject.Find("Joystick").transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        transform.position = targetPosition;
    }
#endif

    void LateUpdate()
    {

        if (ClockManager.C.CS != ClockState.idle && ClockManager.C.CS != ClockState.cooldown)
        {
            targetPosition = followTarget.transform.position;
            //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 7f);
            transform.position = targetPosition;
        }
        else
        {
            //땅에서 조이스틱을 움직이는 중에 내적값을 만족하는 경우
            if (joystickPos.localPosition != Vector3.zero && playerMove.isGround &&
                (Vector2.Dot(joystickPos.anchoredPosition.normalized, joystickPos.up) > 0.9f ||
                Vector2.Dot(joystickPos.anchoredPosition.normalized, joystickPos.up) < -0.9f))
            {
                //조이스틱을 위로 올리면 변수 활성화 후 시간 계산 시작
                if (!joystickUpNDown)
                {
                    joystickUpNDown = true;
                    joystickUpNDownStartTime = Time.time;
                }
                //시간이 흐른 후 카메라 이동
                if (joystickUpNDown && Time.time - joystickUpNDownStartTime > 0.5f)
                {
                    if (Vector2.Dot(joystickPos.anchoredPosition.normalized, joystickPos.up) > 0.9f)
                        targetPosition = playerTrans.position + new Vector3(0, 7, 0);
                    else targetPosition = playerTrans.position + new Vector3(0, -7, 0);
                    //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 3f);
                }
            }
            //조건 만족 안 하면 변수 초기화 후 플레이어 위치를 타겟 위치로 전달
            else
            {
                joystickUpNDown = false;
                targetPosition = playerTrans.position;
                //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 3f);
            }
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 3f);
        }
    }
}
