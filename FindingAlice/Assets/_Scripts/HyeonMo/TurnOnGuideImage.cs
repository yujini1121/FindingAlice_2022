using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnGuideImage : MonoBehaviour
{
    //GuideImage 관련 부모 오브젝트를 할당 해야함
    [SerializeField] GameObject parent;

    IEnumerator turnOnGuide;

    void Start()
    {
        turnOnGuide = parent.GetComponent<GuideImage>().TurnOnGuide();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            parent.GetComponent<GuideImage>().childCount--;

            parent.GetComponent<GuideImage>().guideImages[parent.GetComponent<GuideImage>().childCount].SetActive(true);
            StartCoroutine(turnOnGuide);
            //this.gameObject.SetActive(false);
        }
    }
}