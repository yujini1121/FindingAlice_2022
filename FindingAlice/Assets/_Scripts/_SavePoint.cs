using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SavePoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            PlayerManager.Instance().lastCPPos = transform.position;
            DataController.Instance._gameData.playerPosition = this.transform.position;

            //추가한 것 1006
            for (int i = 0; i < 2; i++)
            {
                if (ClockManager.C.clockCounter == 2) break;
                ClockManager.C.clockCounter++;
            }
        }
    }
}