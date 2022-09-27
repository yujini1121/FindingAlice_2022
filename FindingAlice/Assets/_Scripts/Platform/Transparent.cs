using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

enum Attr
{
    Inst = 0,
    Destroy,
}

public class Transparent : MonoBehaviour
{
    public bool require = false;
    [SerializeField] private float holdingTime = 5.0f;
    private bool isAction = false;

    public int attr;

    public GameObject[] platform;

    private void Start(){
        if (attr == (int)Attr.Inst)
        {
            for (int i = 0; i < platform.Length; i++)
            {
                platform[i].SetActive(false);
            }
        }
        
    }
    
    private void Update() {
        if (!require)
            return;
        if(attr == (int)Attr.Inst) 
        {
            VisibleFunc();
        }
        if(attr == (int)Attr.Destroy)
        {
            DestroyPlatform();
        }
    }

    void VisibleFunc(){
        for(int i = 0; i < platform.Length; i++){
            platform[i].SetActive(true);
        }
        CancelInvoke();
        Invoke("DestroyPlatform", holdingTime);
        require = false;
    }

    private void DestroyPlatform(){
        for(int i = 0; i < platform.Length; i++){
            if (platform[i].gameObject.activeSelf == false)
                break;

            platform[i].SetActive(false);
            Debug.Log($"Destroy{this.gameObject.name}");
        }
    }
}