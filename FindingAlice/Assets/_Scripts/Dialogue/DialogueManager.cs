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

    public bool isActive = false;

    public ObjData objData;
    // 팝업 관리X, 넘기는 것 관리 해야함.
    // 넘기는 키는 업데이트에 있어야함. // gameManager에 넣기

    private void Update()
    {
        if(isActive)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(objData == null)
                return;
                Talk(objData.id, objData.isNpc);
            }
        }
    }
    public void Action(GameObject scanObj)
    {
        if(!isActive)
        {
            isActive = true;
            scanObject = scanObj;
            objData = scanObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNpc);            
        }
        // else
        // {
        //     isActive = false;
        // }

        talkPanel.SetActive(isActive);
    }

    private void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id,talkIndex);
        if(talkData == null)
        {
            isActive = false;
            talkIndex = 0;
            talkPanel.SetActive(isActive);    
            return;
        }
        if(isNpc)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }
        isActive = true;
        talkIndex++;
    }
}
