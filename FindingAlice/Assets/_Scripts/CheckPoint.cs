using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // 체크 포인트 충돌 검사
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            PlayerManager.Instance().lastCPPos = transform.position;
            // 게임 종료시 마지막 저장 위치를 저장해야함.
        }
    }
}
