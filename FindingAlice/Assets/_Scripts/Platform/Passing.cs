using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passing : MonoBehaviour
{
    private GameObject platform;
    private Collider pCollider;

    private void Awake(){
        platform = transform.GetChild(0).gameObject;
        pCollider = platform.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("충돌 확인");
            pCollider.isTrigger = true;
        }
    }
    
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("충돌 끝");
            pCollider.isTrigger = false;
        }
    }
}
