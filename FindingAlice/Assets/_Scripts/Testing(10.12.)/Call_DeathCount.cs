using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Call_DeathCount : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Áö±Ý±îÁöÀÇ ÃÑ »ç¸Á È½¼ö´Â " + GameObject.Find("Player").GetComponentInChildren<PlayerMovement>().deathCounter + "¹ø Á×À¸¼Ì½À´Ï´Ù.");
        Debug.Log("Áö±Ý±îÁöÀÇ ÃÑ »ç¸Á È½¼ö´Â " + PlayerManager.Instance().GetDeathCount() + "¹ø Á×À¸¼Ì½À´Ï´Ù.");
    }


    private void Update()
    {
        if(gameObject.GetComponent<Text>() != null)
        {
            gameObject.GetComponent<Text>().text =
                "»ç¸Á È½¼ö  " + PlayerManager.Instance().GetDeathCount();
        }
    }
}