using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparent : MonoBehaviour
{
    static public bool require = false;
    [SerializeField] private float holdingTime = 5.0f;
    private bool isAction = false;

    public GameObject[] platform;

    private void Awake() {
        // for(int i = 0; i < .Length; i++){
        //     Debug.Log("test");
        //     platform[i] = transform.GetChild(i).gameObject;
        // }
        // platform = this.gameObject.transform.GetChild(0).GameObject;
        platform = GameObject.FindGameObjectsWithTag("Transparent");
    } 
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
            // StartCoroutine(TimeLimitFunc());
            require = false;
        }
    }
    // private IEnumerator TimeLimitFunc(){
    //     platform.SetActive(true);
    //     yield return new WaitForSeconds(holdingTime);
    //     platform.SetActive(false);
    // }
    private void DestroyPlatform(){
        for(int i = 0; i < platform.Length; i++){
            platform[i].SetActive(false);
        }
        Debug.Log($"Destroy{this.gameObject.name}");
    }
}