using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SavePoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Debug.Log("savepoint");
            DataController.Instance.gameData.playerPosition = this.transform.position;
            DataController.Instance.SaveGameData();
        }
    }
}
