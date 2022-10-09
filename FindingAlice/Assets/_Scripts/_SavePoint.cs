using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SavePoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            PlayerManager.Instance().lastCPPos = transform.position;
            DataController.Instance._gameData.playerPosition = this.transform.position;
            
            if(ClockManager.C.clockCounter < 2)
            {
                ClockManager.C.clockCounter = 2;
            }
            
            //ClockManager.C.clockCounter++;
            //ClockManager.C.clockCounter++;
        }
    }
}