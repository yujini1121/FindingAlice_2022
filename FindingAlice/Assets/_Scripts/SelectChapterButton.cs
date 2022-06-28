using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectChapterButton : MonoBehaviour
{
    [SerializeField] private GameObject chapterInfo;
    [SerializeField] private Image chapterInfoImage;
    [SerializeField] private Text chapterInfoSynopsys;
    private ChapterButton test;

    private void Awake() {
        test = GetComponent<ChapterButton>();
    }

    public void PopUpChapter(){
        chapterInfoImage.sprite = test.chapterSO.chapterSprite;
        chapterInfoSynopsys.text = test.chapterSO.synopsys;
        chapterInfo.SetActive(true);
    }
}
