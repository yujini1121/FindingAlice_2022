using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    private float movementRange = 5f; // ��ü�� ������ ����
    private float movementSpeed = 5f; // ��ü�� ������ �ӵ�
    private float collideValue = 50f;

    private Vector3 startPosition; // �ʱ� ��ġ ���� ����
    private float currentMovement; // ���� ������ ���� ����
    private bool isMovingUp; // ���� �����̴��� ���� ���� ����

    void Start()
    {
        startPosition = transform.position;
        currentMovement = 0f;
        isMovingUp = true;
    }

    void Update()
    {
        // ���Ʒ� ������ ���
        if (isMovingUp)
        {
            currentMovement += Time.deltaTime * movementSpeed;
        }
        else
        {
            currentMovement -= Time.deltaTime * movementSpeed;
        }

        // ������ ���� Ȯ��
        if (currentMovement >= movementRange)
        {
            isMovingUp = false;
        }
        else if (currentMovement <= 0f)
        {
            isMovingUp = true;
        }

        // ���ο� ��ġ ���
        Vector3 newPosition = startPosition + Vector3.up * currentMovement;

        // ��ü �̵�
        transform.position = newPosition;
       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.CollideWithObstacle(new Vector3(-collideValue, 0, 0));
        }
    }
        
}
