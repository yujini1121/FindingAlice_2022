﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    static public uint deathCounter;

    [Header("Move")]
    [SerializeField] private float speed;
    private float originSpeed;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCount = 0f;
    [SerializeField] private float jumpTime = 0f;
    private Animator playerAnim;
    private bool isSmartJump = false;
    private float maxJumpCount = 2f;
    private float maxJumpTime = 0.25f;

    //Chapter 2
    private bool isInfiniteJump = true;
    private float originGravity = Physics.gravity.y;
    private float infiniteJumpDelayTime = 0f;

    //Scene - Player 오브젝트
    [HideInInspector] public Rigidbody playerRigidbody;
    //캐릭터 좌우로 이동
    private Vector3 moveDirX;
    //키보드로부터 X축 값 얻음
    private float inputDir;

    [SerializeField] private bool isMoving = false;

    //state
    [SerializeField] private bool _isGround, isJumping, isFalling;
    public bool isDie;

    [SerializeField]
    private bool _collisionToWall = false;

    public bool collisionToWall
    {
        get { return _collisionToWall; }
        set { _collisionToWall = value; }
    }

    public bool isGround
    {
        get { return _isGround; }
        set { _isGround = value; }
    }

    [SerializeField] private DialogueManager dManager;

    [HideInInspector] public static bool respawn;

    EffectSound SFXSound;

    private void Awake()
    {
        gameObject.transform.SetParent(null);
        if (SceneManager.GetActiveScene().name == "tTutorial")
        {
            if (DataController.Instance.gameData.playerPositionTutorial != new Vector3(0, 0, 0))
                transform.position = DataController.Instance.gameData.playerPositionTutorial + new Vector3(0, 5, 0);
        }
        else if (SceneManager.GetActiveScene().name == "Chapter_1")
        {
            transform.position = DataController.Instance.gameData.playerPositionChpater1 + new Vector3(0, 5, 0);
        }
        else if (SceneManager.GetActiveScene().name == "Chapter_2")
        {
            jumpForce = 32f;
            speed = 8f;
        }

        playerAnim = this.GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.useGravity = false;
        originSpeed = speed;

		//SFXSound = GameObject.Find("EffectSound").gameObject.GetComponent<EffectSound>();
	}

    //private void Start()
    //{
    //    originSpeed = speed;
    //    player = GameObject.FindGameObjectWithTag("Player");
    //    playerRigidbody = player.GetComponent<Rigidbody>();
    //    if(ChapterManager.checkLoad)
    //    {
    //        player.transform.position = DataController.Instance.gameData.playerPosition;
    //    }
    //}

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Chapter_2")
        {
            // chapter 2 중력 조정
            if (playerRigidbody.velocity.y < 0)
            {
                Physics.gravity = new Vector3(0, originGravity + 40f, 0);
            }
            else if (playerRigidbody.velocity.y > 0)
            {
                Physics.gravity = new Vector3(0, originGravity, 0);
            }
        }
    }

    private void Update()
    {
        //Debug.Log(CrossPlatformInputManager.GetAxisRaw("Vertical"));
        //Debug.Log(CrossPlatformInputManager.GetAxisRaw("Horizontal"));

        //Chapter 2
        //infiniteJumpDelayTime += Time.deltaTime;
        //Debug.Log(infiniteJumpDelayTime);

        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            Time.timeScale = 0.01f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }

        if (Input.GetKeyDown(KeyCode.X)) 
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            playerAnim.SetBool("isLookUp", true);
        }
        else
        {
            playerAnim.SetBool("isLookUp", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerAnim.SetBool("isLookDown", true);
        }
        else
        {
            playerAnim.SetBool("isLookDown", false);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (PlayerManager.Instance().isGameOver)
            return;

        //플레이어 발 밑 레이캐스트
        Physics.SphereCast(transform.position, 0.2f, -transform.up, out RaycastHit hit_1, 1.63f);
        if (hit_1.collider != null) 
        {
            if (hit_1.collider.tag == "Platform" && LayerMask.LayerToName(hit_1.collider.gameObject.layer) != "PassingPlatform") 
            {
                playerAnim.SetBool("isGrounded", true);
                isGround = true;
                playerAnim.SetBool("isJumping", false);
                isJumping = false;
                playerAnim.SetBool("isFalling", false);
                isFalling = false;
            }
            else if (hit_1.collider.tag == "Platform" && LayerMask.LayerToName(hit_1.collider.gameObject.layer) == "PassingPlatform") 
            {
                playerAnim.SetBool("isGrounded", true);
                isGround = true;
                playerAnim.SetBool("isJumping", false);
                isJumping = false;
                playerAnim.SetBool("isFalling", false);
                isFalling = false;
            }
        }
        else isGround = false;

#if false
        //플레이어 머리 위 레이캐스트
        if (ClockManager.C.CS == ClockState.follow)
        {
            Physics.SphereCast(transform.position, 0.5f, -transform.up, out RaycastHit hit_2, 0.2f);
            if (hit_2.collider != null)
            {
                if (hit_2.collider.tag == "Platform" && LayerMask.LayerToName(hit_2.collider.gameObject.layer) == "PassingPlatform")
                {
                    hit_2.collider.GetComponent<BoxCollider>().isTrigger = true;
                }
            }
        }
        else
        {
            Physics.SphereCast(transform.position, 0.5f, transform.up, out RaycastHit hit_2, 0.55f);
            if (hit_2.collider != null)
            {
                Debug.Log(hit_2.collider.name);
                if (hit_2.collider.tag == "Platform" && LayerMask.LayerToName(hit_2.collider.gameObject.layer) == "PassingPlatform")
                {
                    hit_2.collider.GetComponent<BoxCollider>().isTrigger = true;
                }
            }
        }
#endif

        isMoving = false;
        // 디버깅 개발용 추후 false =======================================================
#if UNITY_ANDROID
        if (CrossPlatformInputManager.GetAxisRaw("Horizontal") != 0)
            Move(CrossPlatformInputManager.GetAxisRaw("Horizontal"));
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
            Jump();
#elif UNITY_EDITOR_WIN
        if (Input.GetAxis("Horizontal") != 0)
            Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
#endif
        CheckJumping();
        playerAnim.SetBool("isWalk", CrossPlatformInputManager.GetAxisRaw("Horizontal") != 0);
        playerAnim.SetBool("isDie", isDie);

    }

    void LateUpdate()
    {
        // smart jump
        if (isGround)
        {
            if (jumpCount == maxJumpCount && jumpTime < maxJumpTime)
                Jump();
            
            jumpCount = 0;
            jumpTime = 0;
            isSmartJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            jumpCount++;

        if (jumpCount == maxJumpCount)
            jumpTime += Time.deltaTime;
    }

    public void Move(float dir = 0)
    {
        if (dManager.isActive || isDie)
        {
            playerAnim.SetBool("isWalk", !dManager.isActive);

            //playerRigidbody.constraints = RigidbodyConstraints.FreezePositionX |RigidbodyConstraints.FreezePositionY;
            //playerRigidbody.constraints = ~RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY;
            //StartCoroutine(FreezeFalse());
            return;
        }

        if (isMoving)
            return;

        if (ClockManager.C.CS == ClockState.idle || ClockManager.C.CS == ClockState.cooldown)
        {
            isMoving = true;

            inputDir = dir;
            if (!collisionToWall && !(CrossPlatformInputManager.GetAxisRaw("Vertical") >= 0.8f || CrossPlatformInputManager.GetAxisRaw("Vertical") <= -0.8f))
            {
                moveDirX = new Vector3(inputDir, 0, 0).normalized;

                transform.position += moveDirX * speed * Time.deltaTime;
            }
            playerAnim.SetBool("isWalk", !_collisionToWall);

            if ((transform.localScale.x > 0 && inputDir < 0) || (transform.localScale.x < 0 && inputDir > 0))
                turnCharacter();
        }
    }

    public void Jump()
    {
        // z키를 누르거나 점프 버튼이 눌렸을 때 플레이어가 땅에 있을 경우 점프
        if (isGround && !isJumping)
        {
            isGround = false;
            playerAnim.Play("Jumping");
            playerAnim.SetBool("isJumping", true);
            isJumping = true;
            //SFXSound.PlaySFX(18000);
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        //Chapter 2
        if (infiniteJumpDelayTime > 0.2f)
        {
            isInfiniteJump = true;
            infiniteJumpDelayTime = 0f;
            //playerRigidbody.velocity = new Vector3(
            //    playerRigidbody.velocity.x, jumpForce, playerRigidbody.velocity.z);
        }
        else
        {
            isInfiniteJump = false;
        }

        //test (위에 input space 코드에서 가져온것)
        //if ((!isJumping || isInfiniteJump) && (infiniteJumpDelayTime < 1.0f))
        //{
        //    isJumping = true;
        //    infiniteJumpDelayTime = 0f;
        //    infiniteJumpDelayTime += Time.deltaTime;
        //    playerRigidbody.velocity = new Vector3(
        //        playerRigidbody.velocity.x, jumpForce, playerRigidbody.velocity.z);
        //}
    }

    private void CheckJumping()
    {
        if ((isJumping && playerRigidbody.velocity.y < 0) || playerRigidbody.velocity.y < -2)
        {
            playerAnim.SetBool("isFalling", true);
            isFalling = true;

            infiniteJumpDelayTime += Time.deltaTime;
            Debug.Log(infiniteJumpDelayTime);
        }
    }

    private void turnCharacter()
    {
        //Debug.Log("회전");
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            speed = originSpeed;
            collisionToWall = false;
            //    if (other.contacts[0].normal.y >= 0.7f)
            //    {
            //        playerAnim.SetBool("isGrounded", true);
            //        isGround = true;
            //        playerAnim.SetBool("isJumping", false);
            //        isJumping = false;
            //        playerAnim.SetBool("isFalling", false);
            //        isFalling = false;
            //    }
        }
    }


    //플랫폼의 기울기에 따라 점프의 여부 판단
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            //if (other.contacts[0].normal.y <= 0.7f)
            //{
            //    isGround = false;
            //    playerAnim.SetBool("isGrounded", false);
            //    return;
            //}
            //else
            //{
            //    playerAnim.SetBool("isGrounded", true);
            //    isGround = true;
            //    playerAnim.SetBool("isJumping", false);
            //    isJumping = false;
            //    playerAnim.SetBool("isFalling", false);
            //    isFalling = false;
            //    return;
            //}
        }
        //playerAnim.SetBool("isRolling", false);
    }
    //플랫폼에서 떨어졌을 때 점프 제한
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            //StartCoroutine(SmoothJump());
        }

        playerAnim.SetBool("isGrounded", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.CompareTag("Attack"))
        //{
        //    PlayerManager.Instance().isGameOver = true;
        //}
        switch (other.tag)
        {
            //case "Platform":
            //    if (ClockManager.C.CS == ClockState.follow)
            //        ClockManager.C.clockReset();

            //    break;
            case "Attack":
            case "TigerClaw":
                GetComponent<Collider>().enabled = false;
                if (transform.parent != null)
                    transform.SetParent(null);
                ClockManager.C.clockReset();

                isDie = true;
                //1007 충돌 시 freezeposition 후, 체크포인트 리스폰 시 다시 해제
                playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;

                respawn = true;
                PlayerManager.Instance().isGameOver = true;
                Debug.Log("으악!");
                break;

            // 팝업만 떠야함
            case "NPC":
                dManager.Action(other.gameObject);
                break;
            default:
                return;
        }
    }

    public void AnimControl(string anim, bool boolean)
    {
        playerAnim.SetBool(anim, boolean);
    }

    public void AnimControl(string anim)
    {
        playerAnim.SetTrigger(anim);
    }

    public void DecreaseSpeed()
    {
        StartCoroutine(_DecreaseSpeed());
    }

    IEnumerator _DecreaseSpeed()
    {
        speed /= 2;
        yield return new WaitForSeconds(0.65f);
        speed = originSpeed;
    }

    IEnumerator SmoothJump()
    {
        yield return new WaitForSeconds(0.15f);
        if (!isGround)
            isGround = false;
    }

    //1008 freeposition
    IEnumerator FreezeFalse()
    {
        yield return new WaitForSeconds(1f);
        //playerRigidbody.constraints = RigidbodyConstraints.None;
        //playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        //playerRigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -transform.up * 1.33f);
        Gizmos.DrawWireSphere(transform.position + (-transform.up * 1.63f), 0.2f);
        Gizmos.DrawWireSphere(transform.position + (transform.up * 0.55f), 0.5f);

    }
}