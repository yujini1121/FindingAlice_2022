using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private Disappear disappear;

    private void Awake(){
        disappear = GetComponentInParent<Disappear>();
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player") && other.contacts[0].normal.y < 0.0f){
            Debug.Log("CollisionEnterTest");
            disappear.checkCollision = true;
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("CollisionExitTest");

            disappear.checkCollision = false;
        }
    }
}
