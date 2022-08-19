using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChapterManager : MonoBehaviour
{
    public Button[] eachChapter;
    private ChapterSO chapterSO;
    private GameObject chapterInfo;
    private GameObject option;
    private GameObject optionButton;
    private Image chapterInfoImage;
    private Text chapterInfoSynopsys;

    private void Awake() {
        chapterInfo = GameObject.FindWithTag("ChapterInfo").transform.GetChild(0).gameObject;
        option = GameObject.Find("Option").transform.GetChild(0).gameObject;
        optionButton = GameObject.Find("OptionButton");
        //chapterSO = GetComponent<Button>()
        // chapterSO = eachChapter.GetComponent<ChapterButton>().chapterSO;
        chapterInfoImage = chapterInfo.transform.Find("ChapterImage").GetComponent<Image>();
        chapterInfoSynopsys = chapterInfo.transform.Find("ChapterSynopsys").GetComponent<Text>();
    }
    
    public void PopUpChapter(int i){
        chapterSO = eachChapter[i].GetComponent<ChapterButton>().chapterSO;
        chapterInfoImage.sprite = chapterSO.chapterSprite;
        chapterInfoSynopsys.text = chapterSO.synopsys;
        optionButton.SetActive(false);
        chapterInfo.SetActive(true);
    }

    public void PopUpOption()
    {
        optionButton.SetActive(false);
        option.SetActive(true);
    }

    public void PopUpOff()
    {
        chapterInfo.SetActive(false);
        option.SetActive(false);
        optionButton.SetActive(true);

    }
}
