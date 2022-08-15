using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    public Text talkName;
    public GameObject scanObject;

    public bool isActive;
    public void Action(GameObject scanObj)
    {
        Debug.Log("다이얼로그 테스트");
        isActive = true;
        scanObject = scanObj;
        talkName.text = scanObject.name;
        talkText.text = "나는" + scanObject.name;
        talkPanel.SetActive(isActive);
    }
}
