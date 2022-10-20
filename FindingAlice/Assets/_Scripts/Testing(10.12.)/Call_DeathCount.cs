using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call_DeathCount : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Áö±İ±îÁöÀÇ ÃÑ »ç¸Á È½¼ö´Â " + GameObject.Find("Player").GetComponentInChildren<PlayerMovement>().deathCounter + "¹ø Á×À¸¼Ì½À´Ï´Ù.");
        Debug.Log("Áö±İ±îÁöÀÇ ÃÑ »ç¸Á È½¼ö´Â " + PlayerMovement.deathCounter + "¹ø Á×À¸¼Ì½À´Ï´Ù.");
    }
}