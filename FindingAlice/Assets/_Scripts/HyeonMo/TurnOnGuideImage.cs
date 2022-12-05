using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnGuideImage : MonoBehaviour
{
    int parentChildCount;

    [SerializeField] bool[] nextButtons;

    [SerializeField] GameObject[] guideImages;

    [SerializeField] Image[] images;
    [SerializeField] Button[] buttons;
    
    void Start()
    {
        parentChildCount = GameObject.Find("GuideImages").transform.childCount;

        guideImages = new GameObject[parentChildCount];
        images = new Image[parentChildCount];
        buttons = new Button[parentChildCount];
        nextButtons = new bool[parentChildCount];

        for (int i = 0; i < parentChildCount; i++)
        {
            guideImages[i] = GameObject.Find("GuideImages").transform.GetChild(i).gameObject;
            guideImages[i].SetActive(false);
        }
        
        for (int i = 0; i < parentChildCount; i++)
        {
            images[i] = guideImages[i].GetComponent<Image>();
            buttons[i] = guideImages[i].GetComponent<Button>();

            buttons[i].enabled = false;
            nextButtons[i] = false;
        }
    }

    void Update()
    {
        for (int i = parentChildCount - 2; i >= 0; i--)
        {
            if (!guideImages[i + 1].activeSelf)
            {
                guideImages[i].SetActive(true);
                break;
            }
            break;
            
        }


    }

    public void OffImages()
    {
        for (int i = 0; i < parentChildCount; i++)
        {
            if (!guideImages[i].activeSelf)
                continue;
            
            guideImages[i].SetActive(false);
            StartCoroutine(TurnOnGuide());
            break;
        }
    }

    //void OnDisable()
    //{
        
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //for (int i = parentChildCount - 1; i >= 0; i--)
            //{
            //    guideImages[i].SetActive(true);
            //}

            guideImages[parentChildCount - 1].SetActive(true);

            StartCoroutine(TurnOnGuide());
        }
    }

    IEnumerator TurnOnGuide()
    {
        yield return new WaitForSeconds(3.0f);

        buttons[parentChildCount - 1].enabled = true;
        nextButtons[parentChildCount - 1] = true;

        for (int i = parentChildCount; i >= 0; i--)
        {
            if (nextButtons[i])
                continue;


            buttons[i].enabled = true;
            nextButtons[i] = true;

            break;
        }

        yield break;
    }
}