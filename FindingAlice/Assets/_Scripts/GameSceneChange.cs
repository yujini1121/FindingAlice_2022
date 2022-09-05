using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneChange : MonoBehaviour
{   
    static public bool checkLoad = false;
    
    public void NewGame(){
        if(DataController.Instance._gameData.playerPosition != new Vector3(0,0,0))
        {
            Debug.Log("데이터 소멸 경고");

            AsyncLoading.LoadScene("GameScene");
            //SceneManager.LoadScene("GameScene");
        }
        else
        AsyncLoading.LoadScene("GameScene");
        //SceneManager.LoadScene("GameScene");
    }

    public void LoadGame(){
        if (DataController.Instance._gameData.playerPosition == new Vector3(0, 0, 0))
        {
            return;
        }
        checkLoad = true;

        AsyncLoading.LoadScene("GameScene");
        //SceneManager.LoadScene("GameScene");
    }
}
