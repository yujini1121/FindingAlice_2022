using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 챕터에서 들어갈 것이 아닌 전체데이터 관리에 들어가야함.
[Serializable]
public class GameData{
    public bool isClearT;
    public bool isClear1;
    public bool isClear2;
    public bool isClear3;

    public bool []hasCP = new bool[3];

    public float bgmValue;
    public float effectValue;
    public bool bgmMute;
    public bool effectMute;
    // playerPosition은 분할 필요.
    public Vector3 playerPosition;
    public bool[] collection = new bool[5];
    public bool[] chT_Collection = new bool[5];
    public bool[] ch1_Collection = new bool[5];
    public bool[] ch2_Collection = new bool[5];
    public bool[] ch3_Collection = new bool[5];
}

[Serializable]
public class ChapterData
{
    // checkPoint info
    // checkPoint에 각각의 숫자를 붙임.
    // 마지막에 닿은 체크포인트의 숫자를 저장
    public int checkNum;
    public Vector3 playerPosition;
    public bool chase;
    // 필요한 state(추후 필요시 마다 추가.)
    // 호랑이 추격 state
    // 
}
