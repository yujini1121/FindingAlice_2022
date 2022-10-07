using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] private GameObject followTarget;
    Transform playerTrans;
    Vector3 targetPosition;
    RectTransform joystickPos;
    bool joystickUpNDown = false;
    float joystickUpNDownStartTime;

    void Start()
    {
        playerTrans = GameObject.Find("Player").transform;
        followTarget = playerTrans.Find("Clock").gameObject;
        joystickPos = GameObject.Find("Joystick").transform.GetChild(0).gameObject.GetComponent<RectTransform>();
    }

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
            if (joystickPos.localPosition != Vector3.zero &&
                (Vector2.Dot(joystickPos.anchoredPosition.normalized, joystickPos.up) > 0.9f ||
                Vector2.Dot(joystickPos.anchoredPosition.normalized, joystickPos.up) < -0.9f))
            {
                if (!joystickUpNDown)
                {
                    joystickUpNDown = true;
                    joystickUpNDownStartTime = Time.time;
                }
                if (joystickUpNDown && Time.time - joystickUpNDownStartTime > 1f)
                {
                    if (Vector2.Dot(joystickPos.anchoredPosition.normalized, joystickPos.up) > 0.9f)
                        targetPosition = playerTrans.position + new Vector3(0, 7, 0);
                    else targetPosition = playerTrans.position + new Vector3(0, -7, 0);
                    transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 3f);
                }
            }
            else
            {
                joystickUpNDown = false;
                targetPosition = playerTrans.position;
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 3f);
            }
        }
    }
}
