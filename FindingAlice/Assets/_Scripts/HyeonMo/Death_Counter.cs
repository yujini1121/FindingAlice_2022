using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Counter : MonoBehaviour
{
    //임시 폐기


    //[SerializeField] uint[] deathCounter = new uint[30];
    public ushort deathCounter;
    string changeInteger;

    void OnEnable()
    {
        //changeInteger = this.gameObject.name;
        //deathCounter = ushort.Parse(changeInteger);
        //Debug.Log(deathCounter); 정상적으로 잘 됨
    }

    void Start()
    {
        
    }

}
