using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider oxygenBar;
    private float maxOxygen;
    private float curOxygen;
    void Start()
    {
        oxygenBar = GetComponent<Slider>();
        maxOxygen = WaterManager.Instance._curOxygen;
       curOxygen = (float)curOxygen / (float)maxOxygen;
        oxygenBar.value = (float)curOxygen / (float)maxOxygen;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SetCurOxygenBar();
    }

    private void SetCurOxygenBar()
    {
        curOxygen = WaterManager.Instance._curOxygen;
        oxygenBar.value = (float)curOxygen / (float)maxOxygen;
    }
}
