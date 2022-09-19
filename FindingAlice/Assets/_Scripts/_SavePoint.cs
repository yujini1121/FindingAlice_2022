using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SavePoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            PlayerManager.Instance().lastCPPos = transform.position;
            DataController.Instance.gameData.playerPosition = this.transform.position;
            if (!DataController.Instance.gameData.hasCP[0])
            {
                DataController.Instance.gameData.hasCP[0] = true;
            }
        }
    }
}
