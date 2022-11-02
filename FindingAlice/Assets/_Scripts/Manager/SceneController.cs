using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private GameData gameData;
    private int[] countLoad;
    GameObject fade;

    bool tPanel;

    private void Awake()
    {
        gameData = DataController.Instance.LoadGameData();
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            if (tPanel)
            {
                if (gameData.isClearT)
                {
                    AsyncLoading.LoadScene("SelectChapterScene");
                    //SceneManager.LoadScene("SelectChapterScene");
                }
                else
                {
                    //for testing apk
                    AsyncLoading.LoadScene("SelectChapterScene");

                    //AsyncLoading.LoadScene("TutorialScene");
                    //SceneManager.LoadScene("TutorialScene");
                }
            }
        }
        else if(CheckChapter(SceneManager.GetActiveScene().name))
        {
            if (fade == null)
                fade = GameObject.Find("FadeImage");
            if (fade.GetComponent<Fade>().check)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    public void TouchPanel()
    {
        tPanel = true;
    }

    bool CheckChapter(string curr)
    {
        for(int i = 0; i < 4; i++)
        {
            if (curr == "Chapter_" + i)
            {
                return true;
            }
        }
        return false;
    }
}
