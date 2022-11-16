using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_OnOff : MonoBehaviour
{
    [SerializeField] bool on = false;
    [SerializeField] bool off = false;

    [SerializeField] GameObject tigerBackGround;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (on && tigerBackGround.activeSelf != true)
            {
                tigerBackGround.SetActive(true);
            }
            
            else if (off)
                tigerBackGround.SetActive(false);

        }
    }
}
