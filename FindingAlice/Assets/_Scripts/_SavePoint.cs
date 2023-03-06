using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SavePoint : MonoBehaviour
{
    //[SerializeField] uint deathCounter;
    [SerializeField] bool lastCheck;


    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            //PlayerManager.Instance().lastCPPos = transform.position;
            if(SceneManager.GetActiveScene().name == "tTutorial")
            {
                DataController.Instance._gameData.playerPositionTutorial = this.transform.position;
                DataController.Instance._gameData.hasCP[0] = true;
                if (lastCheck)
                { 
                    DataController.Instance._gameData.isClearT = true;
                    AsyncLoading.LoadScene("SelectChapterScene");}
                }
            else if(SceneManager.GetActiveScene().name == "Chapter_1")
            {
                DataController.Instance._gameData.playerPositionChpater1 = this.transform.position;
                DataController.Instance._gameData.hasCP[1] = true;
                if (lastCheck)
                    DataController.Instance._gameData.isClear1 = true;
            }
            DataController.Instance.SaveGameData();
            //원래 위에 this.transform~ 인데 this.gameObject.transform으로 바꿈
            
            for (int i = 0; i < 2; i++)
            {
                if (ClockManager.C.clockCounter == 2)
                    break;
                ClockManager.C.clockCounter++;
            }

            gameObject.SetActive(false);
            //gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}