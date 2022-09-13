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
    static public bool checkLoad = false;
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
        //collectionCount.text = $"{CalCollections()} / {DataController.Instance.gameData.collection.Length.ToString()}";
#else
#endif
        optionButton.SetActive(false);
        chapterInfo.SetActive(true);
    }

    // private int CalCollections()
    // {
    //     int count = 0;
    //     for(int i = 0; i < DataController.Instance.gameData.collection.Length - 1; i++)
    //     {
    //         if (DataController.Instance.gameData.collection[i])
    //         {
    //             count++;
    //         }
    //     }
    //     return count;
    // }



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
                AsyncLoading.LoadScene("Chapter_1");
            //SceneManager.LoadScene("GameScene");
        }
        else
        {
            notice.SetActive(false);
            AsyncLoading.LoadScene("Chapter_1");
        }
    }

    public void LoadGame()
    {
        checkLoad = true;

        AsyncLoading.LoadScene("Chapter_1");
        //SceneManager.LoadScene("GameScene");
    }
}
