using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Attr
{
    Inst = 0,
    Destroy,
}

public class Transparent : MonoBehaviour
{
    public bool require = false;

    public float holdingTime = 5.0f;

    public int attr;

    public GameObject[] platform;

    void Start(){
        if (attr == (int)Attr.Inst)
        {
            for (int i = 0; i < platform.Length; i++)
                platform[i].SetActive(false);
        }
    }
    
    void Update() {
        if (!require)
            return;

        if(attr == (int)Attr.Inst) 
            VisibleFunc();
        

        if(attr == (int)Attr.Destroy)
            StartCoroutine(DestroyPlatform()); 
    }

    void VisibleFunc(){
        for(int i = 0; i < platform.Length; i++) 
            platform[i].SetActive(true);
        
        StopCoroutine(DestroyPlatform());
        StartCoroutine(DestroyPlatform());
        require = false;
    }

    IEnumerator DestroyPlatform() {
        if (attr == (int)Attr.Inst)
            yield return new WaitForSeconds(holdingTime);

        for (int i = 0; i < platform.Length; i++) {
            if (platform[i].gameObject.activeSelf == false || platform[i].gameObject == null)
                continue;

            platform[i].SetActive(false);
        }

        if (attr == (int)Attr.Destroy)
        {
            yield return new WaitForSeconds(0.1f);
            this.gameObject.SetActive(false);
        }
        
    }
}