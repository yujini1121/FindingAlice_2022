using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiger_Pattern_Off : MonoBehaviour
{
    //[SerializeField] bool p_Switch = false;

    void Start()
    {
        //p_Switch = GameObject.Find("GameManager").GetComponentInChildren<GameManager>()._patternSwitch;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponentInChildren<GameManager>()._patternSwitch = false;
        }
    }
}