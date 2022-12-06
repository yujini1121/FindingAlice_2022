using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideImage : MonoBehaviour
{
    int childCount = 0;

    //Inspector에서 키려는 GuideImages 오브젝트 할당
    [SerializeField] GameObject parentGuideImages;

    [SerializeField] bool[] nextButtons;

    //기본적으로 SetActive(false)로 할 것
    [SerializeField] GameObject[] guideImages;

    [SerializeField] Image[] images;
    [SerializeField] Button[] buttons;

    void Awake()
    {
        childCount = parentGuideImages.transform.childCount;
    }

    void Start()
    {
        //childCount = parentGuideImages.transform.childCount;

        guideImages = new GameObject[childCount];
        images = new Image[childCount];
        buttons = new Button[childCount];
        nextButtons = new bool[childCount];

        for (int i = 0; i < childCount; i++)
        {
            guideImages[i] = parentGuideImages.transform.GetChild(i).gameObject;

            images[i] = guideImages[i].GetComponent<Image>();
            buttons[i] = guideImages[i].GetComponent<Button>();

            //guideImages[i].SetActive(false);
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

            //guideImages[i - 1].SetActive(true);
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

    IEnumerator TurnOnGuide()
    {
        yield return new WaitForSeconds(3.0f);

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