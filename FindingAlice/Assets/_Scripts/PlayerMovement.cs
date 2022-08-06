using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float speed;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    private Animator playerAnim;

    //Scene - Player 오브젝트
    private GameObject  player;
    private Rigidbody   playerRigidbody;
    //캐릭터 좌우로 이동
    private Vector3     moveDirX;
    //키보드로부터 X축 값 얻음
    private float       inputDir;

    //state
    private bool isGround, isJumping, isFalling;

    [SerializeField]
    private bool _collisionToWall = false;

    public bool collisionToWall
    {
        get { return _collisionToWall; }
        set { _collisionToWall = value; }
    }

    private void Awake()
    {
        playerAnim = this.GetComponent<Animator>();
    }

    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidbody = player.GetComponent<Rigidbody>();
        if(GameSceneChange.checkLoad){
            player.transform.position = DataController.Instance.gameData.playerPosition;
        }
    }

    private void Update() {
        if(!PlayerManager.Instance().isGameOver)
        {
            Move();
            Jump();
            CheckJumping();
        }
    }

    public void Move(float dir = 0){
        if (ClockManager.C.CS == ClockState.idle || ClockManager.C.CS == ClockState.cooldown)
        {
            if (dir == 0) inputDir = Input.GetAxisRaw("Horizontal");
            else inputDir = dir;
            
            if (!_collisionToWall)
            {
                moveDirX = new Vector3(inputDir, 0, 0).normalized;

                transform.position += moveDirX * speed * Time.deltaTime;

                playerAnim.SetBool("isWalk", inputDir != 0);
            }

            if ((transform.localScale.x > 0 && inputDir < 0) || (transform.localScale.x < 0 && inputDir > 0))
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                //turnCharacter();
            }

            //if (inputDir == 0) return;
            //transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, inputDir));
        }
    }
    
    public void Jump(bool pressButton = false){
        // z키를 누르거나 점프 버튼이 눌렸을 때 플레이어가 땅에 있을 경우 점프
        if ((Input.GetKeyDown(KeyCode.Z) || pressButton == true) && isGround)
        {
            playerAnim.SetBool("isJumping", true);
            isJumping = true;
            playerRigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            return;
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
        }
        playerAnim.SetBool("isRolling", false);
        playerAnim.SetBool("isGrounded", true);
        isGround = true;
        playerAnim.SetBool("isJumping", false);
        isJumping = false;
        playerAnim.SetBool("isFalling", false);
        isFalling = false;
    }
    //플랫폼에서 떨어졌을 때 점프 제한
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
            isGround = false;
        playerAnim.SetBool("isGrounded", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Attack"))
        {
            PlayerManager.Instance().isGameOver = true;
        }
    }
}