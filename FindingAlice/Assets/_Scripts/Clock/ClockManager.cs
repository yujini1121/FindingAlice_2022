using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //시계를 눌렀는지 확인
    [SerializeField] bool _isPressKeyClock = false;
    //시계가 벽과 충돌했는지 확인
    [SerializeField] bool _clockCollided = false;
    //시계를 연속 사용하지 못하도록 시계 사용 중 false 됨
    [SerializeField] bool checkClockUse = true;


    public GameObject clock;

    //lever UI Transform
    public RectTransform rect;

    //ClockBackEffect의 메테리얼 저장
    Material clockBackMat;
    //clockBackMat의 Alpha 값 저장
    float clockBackMatAlpha;

    //플레이어의 게임오브젝트와 리지드바디 저장
    GameObject player;
    public GameObject range;
    Rigidbody rb;

    Text text;

    //lever의 transform 저장 벡터
    Vector3 leverTransform;

    float playerColliderHeight;
    float playerColliderRadius;

    //시계 발사 중 시간 속도 설정
    float timeScaleValue = 0.05f;
    //시계 누른 순간의 시간
    float clockStartTime;
    //캐릭터가 시계와 부딪힌 시간
    float clockEndTime;
    float clockReloadStart;
    //시계 쿨타임
    float _clockCooldown = 0.5f;
    //시계 뗀 순간의 시간
    float clockPushUpTime = 0f;
    //시계를 누르고 있던 시간(뗀 시간 - 누른 시간)
    float _clockPushTime = 0f;

    bool dxIsPositive = true;

    [SerializeField] float distance = 2f;

    [SerializeField] int _clockCounter = 2;

    [SerializeField] float dX;
    [SerializeField] float dY;
    //이동 중이던 방향 저장
    [SerializeField] Vector3 keepDir = Vector3.zero;
    [SerializeField] float theta;


    public float clockCooldown
    {
        get { return _clockCooldown; }
        set { _clockCooldown = value; }
    }

    public bool isPressKeyClock
    {
        get { return _isPressKeyClock; }
        set { _isPressKeyClock = value; }
    }

    public bool clockcollided
    {
        get { return _clockCollided; }
        set { _clockCollided = value; }
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
        set { _clockCounter = Mathf.Clamp(value, 0, 2); }
    }

    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        clockBackMat = GameObject.Find("ClockBackEffect").GetComponent<Renderer>().material;
        clockBackMatAlpha = clockBackMat.color.a;
        text = GameObject.Find("ClockCounter").GetComponent<Text>();
        clockMaxRange = range.transform.lossyScale.x * 3.0f;
        playerColliderHeight = player.GetComponent<CapsuleCollider>().height;
        playerColliderRadius = player.GetComponent<CapsuleCollider>().radius;
        clockReset();
    }

    void Update()
    {
        text.text = "Clock : " + clockCounter;
        leverTransform = rect.anchoredPosition.normalized;
        dX = leverTransform.x;
        dY = leverTransform.y;

        //시계 발사 횟수가 2회 이하면서 재충전 시간이 충족된다면 시계 횟수 증가
        if (clockCounter < 2 && Time.time - clockReloadStart > clockReloadTime)
        {
            clockCounter++;
            clockReloadStart = Time.time;
        }

        //X를 눌렀을 때 시간 느리게 만들고 Clock 활성화
        if (Input.GetKeyDown(KeyCode.X) && clockCounter > 0 && checkClockUse && Time.time - clockEndTime > clockCooldown)
        {
            clockCooldown = 0.5f;
            checkClockUse = false;
            clockStartTime = Time.time;
            Time.timeScale = timeScaleValue;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            range.SetActive(true);
            clock.SetActive(true);
            isPressKeyClock = true;
            GameManager.instance.clock = true;
            if (dX < 0) dxIsPositive = false;
        }

        //X를 누르고 있을 때 시계 사출
        if (isPressKeyClock)
        {
            if (distance < clockMaxRange)
            {
                // 시계 사출 중일 때는 뒷 배경을 어둡게 만듦
                clockBackMatAlpha += Time.deltaTime * 20f;
                clockBackMat.color = new Color(0, 0, 0, clockBackMatAlpha);

                distance += clockSpeed * Time.deltaTime;
                //theta = Mathf.Atan2(dY, dX);
                if (leverTransform == Vector3.zero && distance != 0)
                {
                    keepDir = new Vector3(clock.transform.localPosition.x,
                        clock.transform.localPosition.y, 0).normalized;
                    keepDir.x *= distance;
                    keepDir.y *= distance;
                    clock.transform.localPosition = keepDir;
                }
                if (leverTransform != Vector3.zero && !clockcollided)
                {
                    keepDir = new Vector3(dX * distance, dY * distance, 0);
                    //keepDir = new Vector3(Mathf.Cos(theta) * distance, Mathf.Sin(theta) * distance, 0);
                    if (!dxIsPositive) keepDir.x *= -1;
                    clock.transform.localPosition = keepDir; 
                }  
            }
            else
            {
                clockReset();
                return;
            }
        }

        //X를 뗄 때 정상 시간 복귀, Clock으로 플레이어가 날아갈 준비
        if (Input.GetKeyUp(KeyCode.X) && isPressKeyClock)
        {
            clockCounter--;
            isPressKeyClock = false;
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
        }

        // 시계 사출 중이 아닐 때는 어두워진 화면을 원래대로 되돌림
        if (!isPressKeyClock)
        {
            clockBackMatAlpha = Mathf.Lerp(clockBackMatAlpha, 0, Time.deltaTime * 5f);
            clockBackMat.color = new Color(0, 0, 0, clockBackMatAlpha);
        }
    }

    void clockReset()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        clock.transform.SetParent(player.transform, true);
        clock.SetActive(false);
        range.SetActive(false);
        isPressKeyClock = false;
        GameManager.instance.clock = false;
        rb.useGravity = true;
        checkClockUse = true;
        clockcollided = false;
        distance = 0f;

        clockReloadStart = clockEndTime = Time.time;
        clock.transform.localPosition = Vector3.zero;
        dxIsPositive = true;
        player.GetComponent<CapsuleCollider>().height = playerColliderHeight;
        player.GetComponent<CapsuleCollider>().radius = playerColliderRadius;
    }
}
