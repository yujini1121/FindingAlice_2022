using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    // Start is called before the first frame update    
    public float maxOxygen;
    private float curOxygen;
    void Start()
    {
        maxOxygen = 15.0f;
        curOxygen = maxOxygen;
    }

    // Update is called once per frame
    void Update()
    {
        curOxygen -= Time.deltaTime;
        if (curOxygen < 0)
        {
            PlayerManager.Instance().isGameOver = true;
        }
    }
}
