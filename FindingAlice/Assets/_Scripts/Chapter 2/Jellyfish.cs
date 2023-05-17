using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    private float movementRange = 5f; // 물체의 움직임 범위
    private float movementSpeed = 5f; // 물체의 움직임 속도
    private float collideValue = 50f;


    private Vector3 startPosition; // 초기 위치 저장 변수
    private float currentMovement; // 현재 움직임 저장 변수
    private bool isMovingUp; // 위로 움직이는지 여부 저장 변수

    void Start()
    {
        startPosition = transform.position;
        currentMovement = 0f;
        isMovingUp = true;
    }

    void Update()
    {
        // 위아래 움직임 계산
        if (isMovingUp)
        {
            currentMovement += Time.deltaTime * movementSpeed;
        }
        else
        {
            currentMovement -= Time.deltaTime * movementSpeed;
        }

        // 움직임 범위 확인
        if (currentMovement >= movementRange)
        {
            isMovingUp = false;
        }
        else if (currentMovement <= 0f)
        {
            isMovingUp = true;
        }

        // 새로운 위치 계산
        Vector3 newPosition = startPosition + Vector3.up * currentMovement;

        // 물체 이동
        transform.position = newPosition;
       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("충돌");
            playerMovement.CollideWithObstacle(new Vector3(-collideValue, 0, 0));
        }
    }
        
}
