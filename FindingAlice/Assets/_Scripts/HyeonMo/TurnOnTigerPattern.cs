using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTigerPattern : MonoBehaviour
{
    [SerializeField] bool patternOn = false;

    [SerializeField] GameObject tigerBackGround;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (patternOn && !tigerBackGround.activeSelf)
                tigerBackGround.SetActive(true);
            
            else if (!patternOn)
                tigerBackGround.SetActive(false);
        }
    }
}