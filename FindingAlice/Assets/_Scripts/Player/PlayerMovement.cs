using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float speed;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [HideInInspector] public  Animator playerAnim;

    //Scene - Player 오브젝트
    private GameObject  player;
    private Rigidbody   playerRigidbody;
    //캐릭터 좌우로 이동
    private Vector3     moveDirX;
    //키보드로부터 X축 값 얻음
    private float       inputDir;

    [SerializeField] private bool isMoving = false;

    //state
    private bool isGround, isJumping, isFalling;

    [SerializeField]
    private bool _collisionToWall = false;

    public bool collisionToWall
    {
        get { return _collisionToWall; }
        set { _collisionToWall = value; }
    }

    [SerializeField] private DialogueManager dManager;

    private void Awake()
    {
        playerAnim = this.GetComponent<Animator>();
    }

    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidbody = player.GetComponent<Rigidbody>();
        if(ChapterManager.checkLoad){
            player.transform.position = DataController.Instance.gameData.playerPosition;
        }
    }

    private void Update() {
        if(!PlayerManager.Instance().isGameOver)
        {
            isMoving = false;
// 디버깅 개발용 추후 false =======================================================
#if UNITY_EDITOR_WIN
            if (Input.GetAxis("Horizontal") != 0)
                Move(Input.GetAxisRaw("Horizontal"));
            if (Input.GetKeyDown(KeyCode.Space) && isGround)
                Jump();
#endif
            CheckJumping();
        }
    }

    public void Move(float dir = 0){
        if (dManager.isActive)
        {
            playerAnim.SetBool("isWalk", !dManager.isActive);
            return;
        }
        if (isMoving) return;

        if (ClockManager.C.CS == ClockState.idle || ClockManager.C.CS == ClockState.cooldown)
        {
            isMoving = true;

            inputDir = dir;

            if (!_collisionToWall)
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
        //수정점
        isGround = false;

        playerAnim.SetBool("isJumping", true);
        isJumping = true;
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        return;
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

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.CompareTag("Platform"))
    //    {
    //        playerAnim.SetBool("isGrounded", true);
    //        isGround = true;
    //        playerAnim.SetBool("isJumping", false);
    //        isJumping = false;
    //        playerAnim.SetBool("isFalling", false);
    //        isFalling = false;
    //    }
    //}

    //플랫폼의 기울기에 따라 점프의 여부 판단
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            if (other.contacts[0].normal.y <= 0.7f)
            {
                isGround = false;
                playerAnim.SetBool("isGrounded", false);
                return;
            }
            else
            {
                playerAnim.SetBool("isGrounded", true);
                isGround = true;
                playerAnim.SetBool("isJumping", false);
                isJumping = false;
                playerAnim.SetBool("isFalling", false);
                isFalling = false;
            }
        }
        //playerAnim.SetBool("isRolling", false);
    }
    //플랫폼에서 떨어졌을 때 점프 제한
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            //수정점
            StartCoroutine(SmoothJump());
            //isGround = false;
        }
            
        playerAnim.SetBool("isGrounded", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Attack"))
        {
            PlayerManager.Instance().isGameOver = true;
        }
        switch(other.tag){
            // case "Attack":
            // PlayerManager.Instance().isGameOver = true;
            // break;

            // 팝업만 떠야함
            case "NPC":
            dManager.Action(other.gameObject);
            break;
            default:
            return;
        }
    }

    IEnumerator SmoothJump()
    {
        yield return new WaitForSeconds(0.15f);
        isGround = false;
    }
}
