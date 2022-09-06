using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    public bool checkTriggerCondition;  //조건을 만족하면 true

    private float holdingTime = 5.0f;
    private GameObject platform;

    private void Awake(){
        platform = transform.GetChild(0).gameObject;
    }

    private void Update(){
        if(checkTriggerCondition){
            StartCoroutine(TimeLimitFunc());
            checkTriggerCondition = false;
        }
    }

#if false
    private IEnumerator TimeLimitFunc(){
        platform.SetActive(true);
        yield return new WaitForSeconds(holdingTime);
        PlatformManager.SetActive(platform);
    }
#else
    private IEnumerator TimeLimitFunc()
    {
        platform.SetActive(true);
        if (platform.GetComponent<Sink>() != null)
        {
            platform.GetComponent<Sink>().active = true;
        }
        yield return new WaitForSeconds(holdingTime);
        platform.SetActive(false);
    }
#endif
}
