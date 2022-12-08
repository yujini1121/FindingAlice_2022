using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChapterManager : MonoBehaviour
{
    public Button[] eachChapter;
    private ChapterSO chapterSO;
    private GameObject chapterInfo;
    [SerializeField]private GameObject option;
    [SerializeField]private GameObject optionButton;
    private Image chapterInfoImage;
    private Text chapterInfoSynopsys;
    private Text collectionCount;
    public Button loadBtn;

    private int cpN;
    static public bool checkLoad;
    public GameObject notice;

    private void Awake() {
        chapterInfo = GameObject.FindWithTag("ChapterInfo").transform.GetChild(0).gameObject;
        option = GameObject.Find("Option").transform.GetChild(0).gameObject;
        optionButton = GameObject.Find("OptionButton");
        //chapterSO = GetComponent<Button>()
        //chapterSO = eachChapter[].GetComponent<ChapterButton>().chapterSO;
        chapterInfoImage = chapterInfo.transform.Find("ChapterImage").GetComponent<Image>();
        chapterInfoSynopsys = chapterInfo.transform.Find("ChapterSynopsys").GetComponent<Text>();
        collectionCount = chapterInfo.transform.Find("Collections").GetComponent<Text>();

        checkLoad = false;
    }

    public void PopUpChapter(int i){
        cpN = i;
        chapterSO = eachChapter[cpN].GetComponent<ChapterButton>().chapterSO;
        chapterInfoImage.sprite = chapterSO.chapterSprite;
        chapterInfoSynopsys.text = chapterSO.synopsys;
        if (!DataController.Instance.gameData.hasCP[cpN])
        {
            loadBtn.interactable = false;
        }
        else
            loadBtn.interactable = true;

#if true
        switch (cpN)
        {
            case 0:
                collectionCount.text = CalCollections(DataController.Instance.gameData.chT_Collection);
                break;
            case 1:
                collectionCount.text = CalCollections(DataController.Instance.gameData.ch1_Collection); ;
                break;
            case 2:
                collectionCount.text = CalCollections(DataController.Instance.gameData.ch2_Collection); ;
                break;
            case 3:
                collectionCount.text = CalCollections(DataController.Instance.gameData.ch3_Collection); ;
                break;

        }
#else
#endif
        optionButton.SetActive(false);
        chapterInfo.SetActive(true);
    }

    private string CalCollections(bool[] gameData)
    {
        int count = 0;
        for (int i = 0; i < gameData.Length - 1; i++)
        {
            if (gameData[i])
            {
                count++;
            }
        }
        return $"{count} / {gameData.Length.ToString()}";
    }



    public void PopUpOption()
    {
        optionButton.SetActive(false);
        option.SetActive(true);
    }

    public void PopUpOff()
    {
        if (notice.activeSelf)
        {
            notice.SetActive(false);
        }
        else
        {
            chapterInfo.SetActive(false);
            option.SetActive(false);
            DataController.Instance.SaveGameData();
            optionButton.SetActive(true);
        }
    }


    public void NewGame()
    {
        if (!notice.activeSelf)
        {
            if (DataController.Instance.gameData.hasCP[cpN])
            {
                notice.SetActive(true);
                //AsyncLoading.LoadScene("GameScene");
                //SceneManager.LoadScene("GameScene");
            }
            else
            {
                switch (cpN)
                {
                    case 0:
                        AsyncLoading.LoadScene("tTutorial");
                        DataController.Instance._gameData.hasCP[0] = false;
                        DataController.Instance.SaveGameData();
                        break;
                    case 1:
                        AsyncLoading.LoadScene("Chapter_1");
                        DataController.Instance._gameData.playerPositionChpater1 = new Vector3(-822, 10, 0);
                        DataController.Instance._gameData.hasCP[1] = false;
                        DataController.Instance.SaveGameData();
                        break;
                    case 2:
                        AsyncLoading.LoadScene("Chapter_2");
                        break;
                    case 3:
                        AsyncLoading.LoadScene("Chapter_3");
                        break;
                }
            }
            //SceneManager.LoadScene("GameScene");
        }
        else
        {
            notice.SetActive(false);
            switch (cpN)
            {
                case 0:
                    AsyncLoading.LoadScene("tTutorial");
                    DataController.Instance._gameData.playerPositionTutorial = new Vector3(-270, 116, 0);
                    DataController.Instance._gameData.hasCP[0] = false;
                    DataController.Instance.SaveGameData();
                    break;
                case 1:
                    AsyncLoading.LoadScene("Chapter_1");
                    DataController.Instance._gameData.playerPositionChpater1 = new Vector3(-822, 10, 0);
                    DataController.Instance._gameData.hasCP[1] = false;
                    DataController.Instance.SaveGameData();
                    break;
                case 2:
                    AsyncLoading.LoadScene("Chapter_2");
                    break;
                case 3:
                    AsyncLoading.LoadScene("Chapter_3");
                    break;
            }
        }
    }

    public void LoadGame()
    {
        checkLoad = true;
        switch (cpN)
        {
            case 0:
                AsyncLoading.LoadScene("tTutorial");
                break;
            case 1:
                AsyncLoading.LoadScene("Chapter_1");
                break;
            case 2:
                AsyncLoading.LoadScene("Chapter_2");
                break;
            case 3:
                AsyncLoading.LoadScene("Chapter_3");
                break;
        }
        //AsyncLoading.LoadScene("Chapter_1");
        //SceneManager.LoadScene("GameScene");
    }
}
