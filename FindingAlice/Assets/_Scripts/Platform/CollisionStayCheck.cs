using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionStayCheck : MonoBehaviour
{
    private Sink sink;

    private void Awake(){
        sink = GetComponentInParent<Sink>();
    }
    private void OnCollisionStay(Collision other) {
        if(other.gameObject.CompareTag("Player") && other.contacts[0].normal.y < 0.0f){
            other.transform.SetParent(transform);
            sink.checkCollison = true;
        }        
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            other.transform.SetParent(null);
            sink.checkCollison = false;
        }
    }
}
