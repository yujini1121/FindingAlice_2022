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
            {
                DataController.Instance._gameData.playerPositionTutorial = this.transform.position;
            }
            else if(SceneManager.GetActiveScene().name == "Chapter_1")
            {
                DataController.Instance._gameData.playerPositionChpater1 = this.transform.position;
            }
            //원래 위에 this.transform~ 인데 this.gameObject.transform으로 바꿈
            
            for (int i = 0; i < 2; i++)
            {
                if (ClockManager.C.clockCounter == 2)
                    break;
                ClockManager.C.clockCounter++;
            }

            //gameObject.Setactive(false);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}