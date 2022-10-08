using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ClockState
{
    cooldown,
    idle,
    shoot,
    shootMaximum,
    follow
}

public class ClockManager : MonoBehaviour
{
    public static ClockManager C;
    private void Awake()
    {
        if (C == null) C = this;
        else if (C != this) Destroy(gameObject);
        player = GameObject.FindGameObjectWithTag("Player");

        clock = player.transform.Find("Clock").gameObject;
    }

    [Header("Value")]
    [SerializeField] float clockSpeed = 100000f;
    [SerializeField] float clockReloadTime = 3f;
    [SerializeField] float clockMaxRange = 0.05f;
    //시계 쿨타임
    [SerializeField] float _clockCooldown = 0.5f;

    //시계의 상태를 책정할 열거형 변수
    [SerializeField] ClockState _CS;

    public GameObject clock;

    //ClockBackEffect의 메테리얼 저장
    Material clockBackMat;
    //clockBackMat의 Alpha 값 저장
    float clockBackMatAlpha;

    //플레이어의 게임오브젝트와 리지드바디 저장
    GameObject player;
    public GameObject range;
    Rigidbody rb;

    GameObject[] clock_UI = new GameObject[2];

    //lever의 transform 저장 벡터
    [SerializeField] Vector3 _touchAndDragPos = Vector3.zero;

    float playerColliderHeight;
    float playerColliderRadius;

    //시계 발사 중 시간 속도 설정
    float timeScaleValue = 0.05f;
    //시계 누른 순간의 시간
    float clockStartTime;
    //캐릭터가 시계와 부딪힌 시간
    float clockEndTime;
    float clockReloadStart;
    //시계 뗀 순간의 시간
    float clockPushUpTime = 0f;
    //시계를 누르고 있던 시간(뗀 시간 - 누른 시간)
    float _clockPushTime = 0f;

    bool dxIsPositive = true;

    [SerializeField] float distance = 2f;

    [SerializeField] int _clockCounter = 2;

    float dX;
    float dY;
    //이동 중이던 방향 저장
    Vector3 keepDir = Vector3.zero;
    float theta;
    float clockDistanceMaximumTime;

    public Vector3 touchAndDragPos
    {
        get { return _touchAndDragPos; }
        set { _touchAndDragPos = value; }
    }

    public ClockState CS
    {
        get { return _CS; }
        set { _CS = value; }
    }

    public float clockCooldown
    {
        get { return _clockCooldown; }
        set { _clockCooldown = value; }
    }

    public float clockPushTime
    {
        get { return _clockPushTime; }
        set { _clockPushTime = value; }
    }

    //시계 최소 0개, 최대 2개로 제한
    public int clockCounter
    {
        get { return _clockCounter; }
        set
        {
            int temp = _clockCounter;
            _clockCounter = Mathf.Clamp(value, 0, 2);

            if (temp < _clockCounter)
                for (int i = 0; i< _clockCounter; i++)
                    clock_UI[i].SetActive(true);
            else if (temp > _clockCounter)
                clock_UI[_clockCounter].SetActive(false);
            //if (temp < _clockCounter)
            //    clock_UI[_clockCounter - 1].SetActive(true);
            //else if (temp > _clockCounter)
            //    clock_UI[_clockCounter].SetActive(false);
        }
    }


    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        clockBackMat = GameObject.Find("ClockBackEffect").GetComponent<Renderer>().material;
        clockBackMatAlpha = clockBackMat.color.a;
        
        for (int i = 0; i < 2; i++)
            clock_UI[i] = GameObject.Find("ClockCounter").transform.GetChild(i).gameObject;

        clockMaxRange = range.transform.lossyScale.x * 3.0f;
        playerColliderHeight = player.GetComponent<CapsuleCollider>().height;
        playerColliderRadius = player.GetComponent<CapsuleCollider>().radius;
        clockReset();
    }

    void Update()
    {
        dX = touchAndDragPos.x;
        dY = touchAndDragPos.y;

        if (clockCounter == 2)
            clockReloadStart = Time.time;

        //시계 발사 횟수가 2회 이하면서 재충전 시간이 충족된다면 시계 횟수 증가
        if (clockCounter < 2 && Time.time - clockReloadStart > clockReloadTime)
        {
            clockCounter++;
            clockReloadStart = Time.time;
        }

        switch(CS)
        {
            // 시계 사출 중이 아닐 때는 어두워진 화면을 원래대로 되돌림
            case ClockState.cooldown:
                if (clockBackMat.color.a > 0)
                {
                    clockBackMatAlpha = Mathf.Lerp(clockBackMatAlpha, 0, Time.deltaTime * 5f);
                    clockBackMat.color = new Color(0, 0, 0, clockBackMatAlpha);
                }
                if (Time.time - clockEndTime > clockCooldown)
                {
                    CS = ClockState.idle;
                }
                break;

            // 시계 사출 중이 아닐 때는 어두워진 화면을 원래대로 되돌림
            case ClockState.idle:
                if (clockBackMat.color.a > 0)
                {
                    clockBackMatAlpha = Mathf.Lerp(clockBackMatAlpha, 0, Time.deltaTime * 5f);
                    clockBackMat.color = new Color(0, 0, 0, clockBackMatAlpha);
                }
                break;

            //X를 누르고 있을 때 시계 사출
            case ClockState.shoot:
                if (distance < clockMaxRange)
                {
                    player.GetComponent<PlayerMovement>().isGround = false;
                    // 시계 사출 중일 때는 뒷 배경을 어둡게 만듦
                    clockBackMatAlpha += Time.deltaTime * 20f;
                    clockBackMat.color = new Color(0, 0, 0, clockBackMatAlpha);

                    distance += clockSpeed * Time.deltaTime;

                    //캐릭터 방향에 따라 dX의 부호 변환(안 할 시 시계 방향 오류 생김)
                    if (player.transform.localScale.x < 0)
                        dX = -dX;

                    keepDir = new Vector3(dX * distance, dY * distance, 0);
                    clock.transform.localPosition = keepDir;
                    clock.transform.rotation = Quaternion.Euler(new Vector3(Mathf.Atan2(
                        clock.transform.position.x - player.transform.position.x,
                        clock.transform.position.y - player.transform.position.y) * Mathf.Rad2Deg, 90f, -90f));
                }
                else
                {
                    clockDistanceMaximumTime = Time.time;
                    CS = ClockState.shootMaximum;
                }
                break;

            case ClockState.shootMaximum:
                if (Time.time - clockDistanceMaximumTime < 0.1f)
                {
                    Vector3 rotation = new Vector3(Mathf.Atan2(
                        clock.transform.position.x - player.transform.position.x,
                        clock.transform.position.y - player.transform.position.y) * Mathf.Rad2Deg, 90f, -90f);

                    //캐릭터 방향에 따라 dX의 부호 변환(안 할 시 시계 방향 오류 생김)
                    if (player.transform.localScale.x < 0)
                    {
                        dX = -dX;
                        rotation.x += 180;
                    }

                    keepDir = new Vector3(dX * distance, dY * distance, 0);
                    clock.transform.localPosition = keepDir;
                    clock.transform.rotation = Quaternion.Euler(rotation);
                }
                else
                {
                    clockReset();
                }
                break;

            //X를 뗄 때 정상 시간 복귀, Clock으로 플레이어가 날아갈 준비
            case ClockState.follow:
                clockBackMatAlpha = Mathf.Lerp(clockBackMatAlpha, 0, Time.deltaTime * 5f);
                clockBackMat.color = new Color(0, 0, 0, clockBackMatAlpha);
                break;
        }
    }

    public void clockPreparatoryAction()
    {
        clockCooldown = 0.5f;
        clockStartTime = Time.time;
        Time.timeScale = timeScaleValue;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        range.SetActive(true);
        clock.SetActive(true);
        if (dX < 0) dxIsPositive = false;
    }

    public void clockReset()
    {
        Debug.Log("Reset");
        CS = ClockState.cooldown;

        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        clock.transform.SetParent(player.transform, true);
        clock.SetActive(false);
        range.SetActive(false);
        rb.useGravity = true;
        distance = 0f;

        clockReloadStart = clockEndTime = Time.time;
        clock.transform.localPosition = Vector3.zero;
        dxIsPositive = true;


        player.GetComponent<CapsuleCollider>().height = playerColliderHeight;
        player.GetComponent<CapsuleCollider>().radius = playerColliderRadius;
    }

    public void clockFollowAction()
    {
        clockCounter--;
        
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        clock.transform.parent = null;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        clockPushUpTime = Time.time;
        _clockPushTime = clockPushUpTime - clockStartTime;
        range.SetActive(false);

        player.GetComponent<CapsuleCollider>().height = 0;
        player.GetComponent<CapsuleCollider>().radius = 0.3f;
        //화면에 시계가 존재할 때 캐릭터의 속도를 0으로 초기화, 시계의 방향으로 캐릭터 이동
        rb.AddForce((clock.transform.position - player.transform.position).normalized *
            (20 + Mathf.Pow(Vector3.Distance(clock.transform.position, player.transform.position) / 3, 2)), ForceMode.Impulse);
        Debug.Log("follow 모든 동작 완료");
    }
}
