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
#if false
//for testing
            if(gameData.isClearT)
            {
                AsyncLoading.LoadScene("SelectChapterScene");
                //SceneManager.LoadScene("SelectChapterScene");
            }
            else
            {
                AsyncLoading.LoadScene("TutorialScene");
                //SceneManager.LoadScene("TutorialScene");
            }
#endif
            AsyncLoading.LoadScene("SelectChapterScene");
        }
    }
}
