using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnGuideImage : MonoBehaviour
{
    //해당 스크립트는 Guide관련 모든 오브젝트에 할당해야 합니다.

    int childCount = 0;

    [SerializeField] GameObject parentGuideImages; 
    //위의 변수에는 Inspector에서 키려는 GuideImages 오브젝트 할당
    

    [SerializeField] bool[] nextButtons;

    [SerializeField] GameObject[] guideImages;

    [SerializeField] Image[] images;
    [SerializeField] Button[] buttons; //응쓰게싸

    //void Awake()
    //{
    //    if (parentGuideImages == null)
    //    {
    //        if (this.transform.GetComponent<RectTransform>())
    //        {
    //            parentGuideImages = this.transform.gameObject;
    //            Debug.Log(this.gameObject.name + "정상");

    //            if (parentGuideImages.transform.GetChild(0) == null)
    //                parentGuideImages = parentGuideImages.transform.parent.gameObject;
    //        }

    //        else if (this.transform.GetComponent<Transform>())
    //            Debug.Log(this.transform.name + "이라는 오브젝트에 GuideImage가 할당되지 않았습니다.");
    //    }
    //}

    void Start()
    {
        childCount = parentGuideImages.transform.childCount;

        guideImages = new GameObject[childCount];
        images = new Image[childCount];
        buttons = new Button[childCount];
        nextButtons = new bool[childCount];

        //Debug.Log(this.gameObject.name + "Start 정상");

        for (int i = 0; i < childCount; i++)
        {
            //Debug.Log(this.gameObject.name + "for문 시작 전");
            guideImages[i] = parentGuideImages.transform.GetChild(i).gameObject;
            
            images[i] = guideImages[i].GetComponent<Image>();
            buttons[i] = guideImages[i].GetComponent<Button>();

            buttons[i].enabled = false;
            nextButtons[i] = false;
            guideImages[i].SetActive(false);

            //Debug.Log(this.gameObject.name + "for문 정상 실행, (" + i +")번째");
        }

    }

    public void OffImages()
    {
        for (int i = childCount - 1; i >= 0; i++)
        {
            if (i <= 0)
                break;

            if (!guideImages[i].activeSelf)
                continue;
            
            guideImages[i].SetActive(false);
            StartCoroutine(TurnOnGuide());
            break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            guideImages[childCount - 1].SetActive(true);

            StartCoroutine(TurnOnGuide());
        }
    }

    //void OnDisable()
    //{
    //    for (int i = childCount - 1; i >= 0; i--)
    //    {
    //        if (i <= 0)
    //            break;

    //        if (this.transform.gameObject == guideImages[i])
    //        {
    //            guideImages[i - 1].SetActive(true);
    //            break;
    //        }
    //    }
    //}

    IEnumerator TurnOnGuide()
    {
        yield return new WaitForSeconds(3.0f);

        buttons[childCount - 1].enabled = true;
        nextButtons[childCount - 1] = true;

        for (int i = childCount - 1; i >= 0; i--)
        {
            if (i <= 0)
                break;

            if (nextButtons[i])
                continue;

            buttons[i].enabled = true;
            nextButtons[i] = true;

            break;
        }

        yield break;
    }
}