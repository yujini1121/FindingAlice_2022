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
            if (on)
            {
                tigerBackGround.SetActive(true);
                GameObject.Find("GameManager").GetComponentInChildren<GameManager>()._patternSwitch = true;
            }
            
            else if (off)
            {
                GameObject.Find("GameManager").GetComponentInChildren<GameManager>()._patternSwitch = false;
                tigerBackGround.GetComponent<TigerPattern>().pattern.SetActive(false);
                tigerBackGround.GetComponent<TigerPattern>().claw.SetActive(false);
                tigerBackGround.GetComponent<TigerPattern>().rock.SetActive(false);
                tigerBackGround.SetActive(false);
            }

        }
    }
}
