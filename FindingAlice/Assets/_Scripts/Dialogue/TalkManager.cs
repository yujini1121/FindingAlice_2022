using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    private void GenerateData() // 데이터 만드는 함수
    {
        talkData.Add(1000, new string[] { "안녕?", "이 곳에 처음 왔구나?"});
        talkData.Add(2000, new string[] {"잘가"});
    }

    public string GetTalk(int id, int talkIndex)
    {
        if(talkIndex == talkData[id].Length)
            
            return null;
        else
            return talkData[id][talkIndex];
    }
}
