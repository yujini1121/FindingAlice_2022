using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float speed;
    private float originSpeed;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [HideInInspector] private Animator playerAnim;

    //Scene - Player 오브젝트
    private GameObject  player;
    public Rigidbody   playerRigidbody; //1008 PlayerManager에서 사용하기 위한
    //캐릭터 좌우로 이동
    private Vector3     moveDirX;
    //키보드로부터 X축 값 얻음
    private float       inputDir;

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

    private void Awake()
    {
        playerAnim = this.GetComponent<Animator>();
    }

    private void Start()
    {
        originSpeed = speed;
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidbody = player.GetComponent<Rigidbody>();
        if(ChapterManager.checkLoad){
            player.transform.position = DataController.Instance.gameData.playerPosition;
        }
    }

    private void Update() {
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

        if(!PlayerManager.Instance().isGameOver)
        {
            //플레이어 발 밑 레이캐스트
            Physics.SphereCast(transform.position, 0.2f, -transform.up, out RaycastHit hit_1, 1.63f);
            if (hit_1.collider != null) {
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

            ////플레이어 머리 위 레이캐스트
            //if (ClockManager.C.CS == ClockState.follow)
            //{
            //    Physics.SphereCast(transform.position, 0.5f, -transform.up, out RaycastHit hit_2, 0.2f);
            //    if (hit_2.collider != null)
            //    {
            //        if (hit_2.collider.tag == "Platform" && LayerMask.LayerToName(hit_2.collider.gameObject.layer) == "PassingPlatform")
            //        {
            //            hit_2.collider.GetComponent<BoxCollider>().isTrigger = true;
            //        }
            //    }
            //}
            //else
            //{
            //    Physics.SphereCast(transform.position, 0.5f, transform.up, out RaycastHit hit_2, 0.55f);
            //    if (hit_2.collider != null)
            //    {
            //        Debug.Log(hit_2.collider.name);
            //        if (hit_2.collider.tag == "Platform" && LayerMask.LayerToName(hit_2.collider.gameObject.layer) == "PassingPlatform")
            //        {
            //            hit_2.collider.GetComponent<BoxCollider>().isTrigger = true;
            //        }
            //    }
            //}
            


            isMoving = false;
// 디버깅 개발용 추후 false =======================================================
#if UNITY_EDITOR_WIN
            if (Input.GetAxis("Horizontal") != 0)
                Move(Input.GetAxisRaw("Horizontal"));
            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
#endif
            CheckJumping();
            playerAnim.SetBool("isDie", isDie);
        }
    }

    public void Move(float dir = 0){
#if false
        if (dManager.isActive || isDie)
        {
            playerAnim.SetBool("isWalk", !dManager.isActive);
            return;
        }

#else 
        if (dManager.isActive || isDie)
        {
            playerAnim.SetBool("isWalk", !dManager.isActive);

            //playerRigidbody.constraints = RigidbodyConstraints.FreezePositionX |RigidbodyConstraints.FreezePositionY;
            //playerRigidbody.constraints = ~RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY;
            //StartCoroutine(FreezeFalse());

            return;
        }


#endif

        if (isMoving)
            return;

        if (ClockManager.C.CS == ClockState.idle || ClockManager.C.CS == ClockState.cooldown)
        {
            isMoving = true;

            inputDir = dir;

            if (!collisionToWall)
            {
                moveDirX = new Vector3(inputDir, 0, 0).normalized;

                transform.position += moveDirX * speed * Time.deltaTime;
            }
            playerAnim.SetBool("isWalk", !_collisionToWall);


            if ((transform.localScale.x > 0 && inputDir < 0) || (transform.localScale.x < 0 && inputDir > 0))
            {
                turnCharacter();
            }
        }
    }
    
    public void Jump(){
        // z키를 누르거나 점프 버튼이 눌렸을 때 플레이어가 땅에 있을 경우 점프
        if (isGround)
        {
            isGround = false;
            playerAnim.Play("Jumping");
            playerAnim.SetBool("isJumping", true);
            isJumping = true;
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void CheckJumping()
    {
        if ((isJumping && playerRigidbody.velocity.y < 0) || playerRigidbody.velocity.y < -2)
        {
            playerAnim.SetBool("isFalling", true);
            isFalling = true;
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
        switch(other.tag){
            case "Attack":
                isDie = true;
                //1007 충돌 시 freezeposition 후, 체크포인트 리스폰 시 다시 해제
                playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;

                PlayerManager.Instance().isGameOver = true;
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
