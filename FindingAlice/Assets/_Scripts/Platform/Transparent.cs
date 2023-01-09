using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Attr
{
    Inst = 0,
    Transparent,
    appear,
}

public class Transparent : MonoBehaviour
{
    public bool require = false;

    public float holdingTime = 5.0f;

    public int attr;

    public GameObject[] platform;

    void Start(){
        if (attr == (int)Attr.Inst || attr == (int)Attr.appear){
            for (int i = 0; i < platform.Length; i++)
                platform[i].SetActive(false);
        }
    }
    
    void Update() {
        if (!require)
            return;

        switch (attr)
        {
            case ((int)Attr.Inst):
                VisibleFunc();
                break;

            case ((int)Attr.Transparent):
                StartCoroutine(TransparentPlatform());
                break;

            case ((int)Attr.appear):
                for (int i = 0; i < platform.Length; i++)
                    platform[i].SetActive(true);
                break;

            default:
                print("Attr를 다시 확인하세요.");
                break;
        }
    }

    void VisibleFunc(){
        for(int i = 0; i < platform.Length; i++) 
            platform[i].SetActive(true);

        StopCoroutine(TransparentPlatform());
        StartCoroutine(TransparentPlatform());
        require = false;
    }

    IEnumerator TransparentPlatform() {
        if (attr == (int)Attr.Inst)
            yield return new WaitForSeconds(holdingTime);

        for (int i = 0; i < platform.Length; i++) {
            if (platform[i].gameObject.activeSelf == false || platform[i].gameObject == null)
                continue;

            platform[i].SetActive(false);
        }
    }
}