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
    public GameObject waringImage;
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
        waringImage.SetActive(false);
    }

    void Update()
    {
        OnTriggerStay(playerCollider);      //산소 공간 입력 확인 
        OnTriggerExit(playerCollider);

        if(curOxygen <= maxOxygen)
        {
            curOxygen -= (int)oxygenType * Time.deltaTime;
        }

        if (curOxygen < 0)
        {
            PlayerManager.Instance().isGameOver = true;
        }
        else if (curOxygen > maxOxygen)
        {
            curOxygen = maxOxygen;
        }
        else if (curOxygen < 5)
        {
            waringImage.SetActive(true);
        }
    }

    void OnTriggerStay(Collider collider)   //산소 공간 안으로 들어왔을때
    {
        if (!isInOxygenArea && collider.gameObject.CompareTag("OxygenArea"))    //isInOxygenArea없으면 계속 게임오브젝트의 tag를 탐색하므로 비용 발생
        {
            isInOxygenArea = true;
            oxygenType = OxygenType.AddOxygen;
            Debug.Log("플레이어가 박스 안으로 들어왔습니다.");
        }
    }

    void OnTriggerExit(Collider collider)   //산소 공간 밖으로 들어왔을때
    {
        if (isInOxygenArea && collider.gameObject.CompareTag("OxygenArea"))
        {
            isInOxygenArea = false;
            oxygenType =  OxygenType.MinusOxygen;
            Debug.Log("플레이어가 박스 밖으로 떠났습니다.");
        }
    }
}
