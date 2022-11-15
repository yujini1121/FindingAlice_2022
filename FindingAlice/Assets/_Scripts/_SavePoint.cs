using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SavePoint : MonoBehaviour
{
    //[SerializeField] uint deathCounter;

    void Start()
    {
        //deathCounter = transform.GetComponentInParent<Death_Counter>().deathCounter;
    }


    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            //PlayerManager.Instance().lastCPPos = transform.position;
            if(SceneManager.GetActiveScene().name == "tTutorial")
                DataController.Instance._gameData.playerPositionTutorial = this.transform.position;
            else if(SceneManager.GetActiveScene().name == "Chapter_1")
                DataController.Instance._gameData.playerPositionChpater1 = this.transform.position;
            
            for (int i = 0; i < 2; i++)
            {
                if (ClockManager.C.clockCounter == 2)
                    break;
                ClockManager.C.clockCounter++;
            }

            //22.10.10. 체크포인트 없어지도록 설정
            gameObject.SetActive(false);
        }
    }
}