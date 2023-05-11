using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    enum OxygenType {AddOxygen = -1,MinusOxygen = +1 }
    //=========================================
    //싱글톤
    private WaterManager() { }
    public GameObject warningImage;
    private static WaterManager instance = null;
    public static WaterManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WaterManager();
            }
            return instance;
        }
    }
    //========================================
    public float maxOxygen;
    private float curOxygen;
    private bool isInOxygenArea;

    private OxygenType oxygenType;
    private bool isWarning = false;
    private Collider playerCollider;
    public float _curOxygen
    {
        get { return curOxygen; }
        set { curOxygen = value; }
    }
    public float _maxOxygen
    {
        get { return maxOxygen; }
        set { maxOxygen = value; }
    }

    void Awake()
    {
        instance = this;
        maxOxygen = 15.0f;
        curOxygen = maxOxygen;
        oxygenType = OxygenType.MinusOxygen;
        playerCollider = GetComponent<Collider>();
        warningImage.SetActive(false);
    }

    void Update()
    {
        /*if (curOxygen < 0)
        {
            PlayerManager.Instance().isGameOver = true;
        }
        else if (curOxygen <= maxOxygen)
        {
            curOxygen -= (int)oxygenType * Time.deltaTime;
        }
        else if (curOxygen > maxOxygen)
        {
            curOxygen = maxOxygen;
        }
        else if (!isWarning && curOxygen < 5)
        {
            isWarning = true;
            warningImage.SetActive(true);
        }
        else if (isWarning && curOxygen >= 5)
        {
            isWarning = false;
            warningImage.SetActive(false);
        }*/
       curOxygen = Mathf.Clamp(curOxygen, 0, maxOxygen);

        if (curOxygen <= 0)
        {
            PlayerManager.Instance().isGameOver = true;
        }
        else
        {
            curOxygen -= (int)oxygenType * Time.deltaTime;

            if (curOxygen < 5)
            {
                isWarning = true;
                warningImage.SetActive(true);

            }
            else
            {
                isWarning = false;
                warningImage.SetActive(false);
            }
        }
}
    public void GetOxygenItem()
    {
        curOxygen += 7.5f;
        if(curOxygen > maxOxygen)
        {
            curOxygen = maxOxygen;
        }
    }
    void OnTriggerStay(Collider collider)   //산소 공간 안으로 들어왔을때
    {
        if (!isInOxygenArea && collider.gameObject.CompareTag("OxygenArea"))    //isInOxygenArea없으면 계속 게임오브젝트의 tag를 탐색하므로 비용 발생
        {
            isInOxygenArea = true;
            oxygenType = OxygenType.AddOxygen;
        }
    }

    void OnTriggerExit(Collider collider)   //산소 공간 밖으로 들어왔을때
    {
        if (isInOxygenArea && collider.gameObject.CompareTag("OxygenArea"))
        {
            isInOxygenArea = false;
            oxygenType =  OxygenType.MinusOxygen;
        }
    }
}
