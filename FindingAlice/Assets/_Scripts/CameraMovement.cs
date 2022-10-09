using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject target;
    public GameObject clock;
    public GameObject player;

    Vector3 targetPosition;
    Vector3 clockPos;
    Vector3 playerPos;
    // clock From Player
    Vector3 cFp;
    [SerializeField]
    float yValue;
    [SerializeField] float t;

    [SerializeField, Range(-5f, -50f)] float zAxis = 10f;

    private void Awake()
    {
        target = GameObject.FindWithTag("CameraTarget").gameObject;
        clock = player.transform.Find("Clock").gameObject;
#if true
        //for testing
        targetPosition = target.transform.position;
#endif
    }

    private void Start()
    {
        clockPos = Vector3.zero;
        playerPos = Vector3.zero;
    }

    private void Update()
    {
        clockPos = new Vector3(clock.transform.position.x, clock.transform.position.y, 0);
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        cFp = clockPos - playerPos;
        yValue = Mathf.Abs(cFp.y);
    }

    private void LateUpdate()
    {
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        t = Time.time - GameManager.instance.idleTime;

        //시계 쏘는 중에 카메라 축소
        if (ClockManager.C.CS == ClockState.shoot)
        {
            //시계와 플레이어의 높이(yValue)와 거리를 곱해서 수직으로 쏠 땐 급격한 축소를 함
            targetPosition.z = -15 + (yValue + 10) * Vector3.Distance(clockPos, playerPos) * -0.1f;
        }
        //시계 쏜 후에 카메라 확대
        if (!(ClockManager.C.CS == ClockState.shoot || ClockManager.C.CS == ClockState.shootMaximum))
        {
            //멈춤
            if (Time.time - GameManager.instance.idleTime > 3f && GameManager.instance.isGround
                && GameObject.Find("Lever").GetComponent<RectTransform>().anchoredPosition.x == 0)
                targetPosition.z = Mathf.Lerp(transform.position.z, -7, Time.deltaTime * 0.2f);
            else 
                targetPosition.z = Mathf.Lerp(transform.position.z, zAxis, Time.deltaTime * 4f);
        }
        transform.position = targetPosition;
    }
}