using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    public Text talkText;
    public Text talkName;
    public GameObject scanObject;
    public int talkIndex;

    public bool isActive;
    public void Action(GameObject scanObj)
    {
        if(isActive)
        {
            isActive = false;
        }
        else
        {
            isActive = true;
            scanObject = scanObj;
            ObjData objData = scanObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNpc);
        }
        talkPanel.SetActive(isActive);
    }

    private void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id,talkIndex);
        if(isNpc)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }
    }
}
