using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTigerPattern : MonoBehaviour
{
    [SerializeField] bool patternOn = false;

    [SerializeField] GameObject tigerBackGround;
    TigerPattern tigerPattern;

    void Start()
    {
        tigerPattern = gameObject.GetComponent<TigerPattern>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (patternOn && !tigerBackGround.activeSelf)
            {
                //if (!tigerPattern.checking)
                //{
                //    tigerBackGround.SetActive(true);

                //    tigerPattern.PatternPlay();
                //    tigerPattern.checking = true;
                //}
                tigerBackGround.SetActive(true);
            }
                
            else if (!patternOn)
            {
                //if (!tigerPattern.checking)
                //{
                //    tigerPattern.PatternExit();
                //    tigerPattern.checking = false;

                //    tigerBackGround.SetActive(false);
                //}
                tigerBackGround.SetActive(false);
            }
        }
    }
}