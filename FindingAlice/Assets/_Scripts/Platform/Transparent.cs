using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    public bool require = false;
    [SerializeField] private float holdingTime = 5.0f;
    private bool isAction = false;

    public GameObject[] platform;

    private void Start(){
        for(int i = 0; i < platform.Length; i++){
            platform[i].SetActive(false);
        }
    }
    
    private void Update() {
        VisibleFunc();
    }

    void VisibleFunc(){
        if(require){
            for(int i = 0; i < platform.Length; i++){
                platform[i].SetActive(true);
            }
            CancelInvoke();
            Invoke("DestroyPlatform", holdingTime);
            require = false;
        }
    }

    private void DestroyPlatform(){
        for(int i = 0; i < platform.Length; i++){
            platform[i].SetActive(false);
        }
        Debug.Log($"Destroy{this.gameObject.name}");
    }
}