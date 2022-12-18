using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int childCount = 0;

    [SerializeField] GameObject parentGuideImages;
    [SerializeField] GameObject nextGuideImage;

    void Start()
    {
        parentGuideImages = transform.parent.gameObject;
        childCount = parentGuideImages.transform.childCount;

        for (int i = childCount - 1; i >= 0; i++)
        {
            if (i == 0)
                break;
            
            if (this.gameObject.name == parentGuideImages.transform.GetChild(i).name)
                nextGuideImage = parentGuideImages.transform.GetChild(i - 1).gameObject;
        }

    }

    void OnDisable()
    {
        nextGuideImage.SetActive(true);
        this.gameObject.SetActive(false);

    }

}
