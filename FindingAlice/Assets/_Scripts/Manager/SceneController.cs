using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private GameData gameData;
    private void Awake()
    {
        gameData = DataController.Instance.LoadGameData();
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (gameData.isClearT)
                {
                    AsyncLoading.LoadScene("SelectChapterScene");
                    //SceneManager.LoadScene("SelectChapterScene");
                }
                else
                {
                    AsyncLoading.LoadScene("TutorialScene");
                    //SceneManager.LoadScene("TutorialScene");
                }
                AsyncLoading.LoadScene("SelectChapterScene");
            }
        }
        //else
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        if (SceneManager.GetActiveScene().name == "Chapter_" + i)
        //        {
        //        }
        //    }
        //}
    }
}
