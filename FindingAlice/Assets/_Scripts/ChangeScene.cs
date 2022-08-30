using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private GameData gameData;
    
    private void Awake()
    {
        gameData = DataController.Instance.LoadGameData();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(gameData.isClearT)
            {
                SceneManager.LoadScene("SelectChapterScene");
            }
            else
            {
                SceneManager.LoadScene("TutorialScene");
            }
        }
    }
}
