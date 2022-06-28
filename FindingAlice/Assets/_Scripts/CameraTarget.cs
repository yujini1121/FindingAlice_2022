using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] private GameObject followTarget;
    Transform playerTrans;
    Vector3 targetPosition;

    void Start()
    {
        playerTrans = GameObject.Find("Player").transform;
        followTarget = playerTrans.Find("Clock").gameObject;
    }

    void LateUpdate()
    {
        if (GameManager.instance.clock)
        {
            targetPosition = followTarget.transform.position;
            transform.position = targetPosition;
        }
        else
        {
            targetPosition = playerTrans.position;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 3f);
        }
    }
}
