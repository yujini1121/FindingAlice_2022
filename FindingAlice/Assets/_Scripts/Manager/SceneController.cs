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
        //gameData = DataController.Instance.LoadGameData();
        gameData = DataController.Instance.LoadGameData();
        DontDestroyOnLoad(this.gameObject);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
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
                else if (!DataController.Instance._gameData.readTutoTalk)
                {
                    //for testing apk
                    AsyncLoading.LoadScene("TutoTalk 1");
                    DataController.Instance._gameData.readTutoTalk = true;

                    //AsyncLoading.LoadScene("TutorialScene");
                    //SceneManager.LoadScene("TutorialScene");
                }
                else
                    AsyncLoading.LoadScene("SelectChapterScene");
            }
        }
        else if(CheckChapter(SceneManager.GetActiveScene().name))
        {
            if (fade == null)
                fade = GameObject.Find("FadeImage");
            if (fade.GetComponent<Fade>().check)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        for (int i = 1; i < 3; i++)
        {
            if (SceneManager.GetActiveScene().name == "TutoTalk " + i)
            {
                if (fade == null)
                    fade = GameObject.Find("FadeImage");
                if (fade.GetComponent<Fade>().check)
                {
                    SceneManager.LoadScene(i + 2);
                }
            }
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
            else if(curr == "tTutorial")
            {
                return true;
            }
        }
        return false;
    }
}
