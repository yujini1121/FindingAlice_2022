using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider oxygenBar;
    private float MaxOxygen = 15;
    private float curOxygen = 15;
   
    void Start()
    {
        oxygenBar = GetComponent<Slider>();
        oxygenBar.value = (float)curOxygen / (float)MaxOxygen;
    }

    // Update is called once per frame
    void Update()
    {
        SetCurOxygenBar();
    }
    private void SetCurOxygenBar()
    {
        curOxygen -= Time.deltaTime;
        if (curOxygen < 0)
        {
            PlayerManager.Instance().isGameOver = true;
        }
        oxygenBar.value = (float)curOxygen / (float)MaxOxygen;
    }
}
