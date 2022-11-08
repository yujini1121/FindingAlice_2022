using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passing : MonoBehaviour
{
    private GameObject platform;
    private Collider pCollider;

    bool col_To_Wall;

    private void Awake(){
        platform = transform.GetChild(0).gameObject;
        pCollider = platform.GetComponent<Collider>();
    }

    void Start()
    {
        col_To_Wall = GameObject.Find("Player").GetComponent<PlayerMovement>().collisionToWall;
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

    void OnCollisionExit(Collision collision)
    {
        //col_To_Wall = false;
    }


}