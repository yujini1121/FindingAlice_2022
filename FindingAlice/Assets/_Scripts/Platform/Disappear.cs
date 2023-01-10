using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public bool checkCollision;
    private float holdingTime = 1.5f;
    private float appearTime = 2.5f;
    [SerializeField] private float realTime = 0.0f;

    private GameObject platform;

    private void Awake(){
        platform = transform.GetChild(0).gameObject;
        checkCollision = false;
    }

    private void Update(){
        if(checkCollision){
        //     realTime += Time.deltaTime;
        //     // StartCoroutine(DisappearFunc());
        //     // checkCollision = false;
        // }else holdingTime = 0.0f;
        // if(realTime >= holdingTime){
        //     //platform.SetActive(false);
        //     //StartCoroutine(DisappearFunc());
        //     checkCollision = false;
            Invoke("DisappearFunc", holdingTime);
            if(!checkCollision && IsInvoking()){
                CancelInvoke();
            }
            checkCollision = false;
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
