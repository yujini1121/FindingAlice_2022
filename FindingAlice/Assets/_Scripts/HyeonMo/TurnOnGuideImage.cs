using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnGuideImage : MonoBehaviour
{
    int parentChildCount;

    bool[] nextButtons;

    [SerializeField] GameObject[] guideImages;

    Image[] images;
    Button[] buttons;
    
    void Start()
    {
        parentChildCount = GameObject.Find("GuideImages").transform.childCount;

        for (int i = 0; i < parentChildCount; i++)
        {
            print("실행완료1");
            //guideImages[i] = GameObject.Find("GuideImages").transform.GetChild(i).gameObject;

            guideImages[i] = GameObject.Find("GuideImage" + i);

            //guideImages[i] = GameObject.Find("Canvas").transform.Find("GuideImages").transform.GetChild(i).gameObject;



        }
        print("Normal"); //스크립트 그냥 분할할 것?
        

        for (int i = 0; i < parentChildCount; i++)
        {
            guideImages[i].SetActive(false);

            images[i] = guideImages[i].GetComponent<Image>();
            buttons[i] = guideImages[i].GetComponent<Button>();

            buttons[i].enabled = false;
            nextButtons[i] = false;
        }
    }

    public void OffImages()
    {
        for (int i = 0; i < parentChildCount; i++)
        {
            if (guideImages[i].activeSelf == false)
                continue;
            
            guideImages[i].SetActive(false);
            StartCoroutine(TurnOnGuide());
            break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.transform.parent.gameObject == null)
        {
            for (int i = 0; i < parentChildCount; i++)
                guideImages[i].SetActive(true);
            

            StartCoroutine(TurnOnGuide());
        }
    }

    IEnumerator TurnOnGuide()
    {
        yield return new WaitForSeconds(3.0f);

        for (int i = 0; i < parentChildCount; i++)
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