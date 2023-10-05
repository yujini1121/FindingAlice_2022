using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squid : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private float movementRange = 5f; 
    private float movementSpeed = 5f; 
    private float collideValue = 50f;

    private Vector3 originPos;

    [SerializeField]
    private GameObject indiaInk;

    // 플레이어와 닿았는지 검사
    public bool isTouched = false;

    void Start()
    {
        originPos = transform.position;
    }

    void Update()
    {
        // Mathf.Sin 사용 
        transform.position = originPos + new Vector3(0, Mathf.Sin(Time.time) * 2.5f, 0);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouched = true;
            indiaInk.gameObject.SetActive(true);
        }
    }
}