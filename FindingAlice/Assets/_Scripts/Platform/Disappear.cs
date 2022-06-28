using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public bool checkCollison = false;
    public bool check = false;
    private float holdingTime = 1.5f;
    private float appearTime = 3.0f;
    [SerializeField] private float realTime = 0.0f;

    private GameObject platform;

    private void Awake(){
        platform = transform.GetChild(0).gameObject;
    }

    private void Update(){
        if(checkCollison){
        //     realTime += Time.deltaTime;
        //     // StartCoroutine(DisappearFunc());
        //     // checkCollison = false;
        // }else holdingTime = 0.0f;
        // if(realTime >= holdingTime){
        //     //platform.SetActive(false);
        //     //StartCoroutine(DisappearFunc());
        //     checkCollison = false;
            checkCollison = false;
            Invoke("DisappearFunc", holdingTime);
            if(!checkCollison && IsInvoking()){
                CancelInvoke();
            }
        }
        
    }

    private void DisappearFunc(){
        platform.SetActive(false);
        Invoke("AppearFunc", appearTime);
    }

    private void AppearFunc(){
        platform.SetActive(true);
    }
    // private IEnumerator DisappearFunc(){
    //     // yield return new WaitForSeconds(holdingTime);
    //     // platform.SetActive(false);
    //     yield return new WaitForSeconds(appearTime);
    //     platform.SetActive(true);
    // }
}
