using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Position
{
    left = 0,
    right = 1,


    max
}

public class TalkData
{
    public string name;
    public Sprite sprite;
    public string talkContents;

    public Position position;
}

public class TalkManager : MonoBehaviour
{
    Dictionary<int, TalkData[]> talkData;
    private void Awake()
    {
        talkData = new Dictionary<int, TalkData[]>();
        GenerateData();

    }

    private void GenerateData() // 데이터 만드는 함수
    {
        TalkData a = new TalkData();
        a.name = "나";
        a.talkContents = "hello";
        a.position = Position.left;
        TalkData b = new TalkData() { name = "너", sprite = null, talkContents = "bye", position = Position.right };
        talkData.Add(1000, new TalkData[]{ a, b });
        Debug.Log(talkData[1000][0].name);
    }

    public TalkData GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)

            return null;
        else
            return talkData[id][talkIndex];
    }
}
