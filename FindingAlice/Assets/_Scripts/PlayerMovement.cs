using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float speed;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] float gravity = 3f;
    
    private Animator playerAnim;

    //Scene - Player 오브젝트
    private GameObject  player;
    private Rigidbody   playerRigidbody;
    //캐릭터 좌우로 이동
    private Vector3     moveDirX;
    //키보드로부터 X축 값 얻음
    private float       inputDir;

    //state
    public bool isGround;
    private bool isJumping;
    private bool isFalling;

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
        Move();
        Jump();
        // if (!(GameManager.instance.isGround || GameManager.instance.clock))
        //     //playerRigidbody.velocity = new Vector3(0, -gravity, 0);
        //     playerRigidbody.AddForce(new Vector3(0, -gravity, 0), ForceMode.Force);
        // physics의 gravity를 10배함.
        // jumpForce를 30
        CheckJumping();
    }

    public void Move(float dir = 0){
        if (!GameManager.instance.clock)
        {
            if (dir == 0) inputDir = Input.GetAxisRaw("Horizontal");
            else inputDir = dir;
            
            if (!_collisionToWall)
            {
                //Debug.Log(dir);
                //Debug.Log(inputDir);
                moveDirX = new Vector3(inputDir, 0, 0).normalized;
                //Debug.Log(moveDirX);

                //playerRigidbody.velocity += moveDirX * speed;
                transform.position += moveDirX * speed * Time.deltaTime;

                playerAnim.SetBool("isWalk", inputDir != 0);
            }

            if (inputDir == 0) return;
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, inputDir));
        }
    }
    
    public void Jump(bool pressButton = false){
        // z키를 누르거나 점프 버튼이 눌렸을 때 플레이어가 땅에 있을 경우 점프
        if ((Input.GetKeyDown(KeyCode.Z) || pressButton == true) && isGround)
        {
            playerAnim.SetBool("isJumping", true);
            isJumping = true;
            //playerRigidbody.velocity = transform.up * jumpForce;
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
            if (GameManager.instance.clock && !ClockManager.C.isPressKeyClock)
            {
                GameObject.Find("ClockManager").SendMessage("clockReset");
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
            PlayerManager.Instance().alive = false;
        }
    }
}

    //사출된 시계와 충돌한 후 감속
    //IEnumerator deceleration()
    //{
    //    for (int i = 0; i < 6; i++)
    //    {
    //        playerRigidbody.velocity *= decelSpeed;
    //        yield return new WaitForSeconds(0.05f);
    //    }
    //}