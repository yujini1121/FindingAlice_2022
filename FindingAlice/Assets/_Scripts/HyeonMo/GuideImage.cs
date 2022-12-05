using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideImage : MonoBehaviour
{
    int childCount;

    GameObject parent;
    GameObject[] child;

    [SerializeField] GameObject[] guideImages;

    void Start()
    {
        parent = this.gameObject;
        childCount = this.transform.childCount;



        for (int i = 0; i < childCount; i++)
        {
            guideImages[i] = transform.GetChild(i).gameObject;

            guideImages[i].SetActive(false);
        }

        //foreach (int count in childCount)
        //{

        //}






    }


    void Update()
    {
        
    }
}
