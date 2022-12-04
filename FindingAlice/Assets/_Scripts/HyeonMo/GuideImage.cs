using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideImage : MonoBehaviour
{
    [SerializeField] GameObject[] guideImages;

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            //guideImages[i] = transform.GetChild(i).gameObject;

            

            //guideImages[i].SetActive(false);
        }







    }


    void Update()
    {
        
    }
}
