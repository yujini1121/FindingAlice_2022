using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTigerPattern : MonoBehaviour
{
    [SerializeField] bool patternOn = false;

    [SerializeField] GameObject tigerBackGround;
    TigerPattern tigerPattern;

    Collider collider;

    void Start()
    {
        tigerPattern = gameObject.GetComponent<TigerPattern>();
        collider = this.gameObject.GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (patternOn && !tigerBackGround.activeSelf)
            {

                tigerBackGround.SetActive(true);

                tigerPattern.PatternPlay();
                
                //tigerBackGround.SetActive(true);
            }
                
            else if (!patternOn)
            {
                
                tigerPattern.PatternExit();

                tigerBackGround.SetActive(false);
                
                //tigerBackGround.SetActive(false);
            }

            //collider.enabled = false;
            this.gameObject.SetActive(false);
        }
    }
}