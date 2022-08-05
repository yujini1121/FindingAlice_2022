using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData{
    public bool isClear1;
    public bool isClear2;
    public bool isClear3;


    // playerPosition은 분할 필요.
    public Vector3 playerPosition;
}

[Serializable]
public class Chaper1Data
{
    // checkPoint info
    // checkPoint에 각각의 숫자를 붙임.
    // 마지막에 닿은 체크포인트의 숫자를 저장
    public int checkNum;

    // 필요한 state(추후 필요시 마다 추가.)
    // 호랑이 추격 state
    // 
}