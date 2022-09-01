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
    public Image[] talkImage;
    public GameObject scanObject;
    public int talkIndex;

    public bool isActive = false;

    public ObjData objData;

    private void Update()
    {
        if(isActive)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(objData == null)
                return;
                Talk(objData.id);
            }
        }
    }
    public void Action(GameObject scanObj)
    {
        if(!isActive)
        {
            scanObject = scanObj;
            objData = scanObject.GetComponent<ObjData>();
            if (objData.checkRead)
                return;
            isActive = true;
            Talk(objData.id);            
        }

        talkPanel.SetActive(isActive);
    }

    private void Talk(int id)
    {
        TalkData talkData = talkManager.GetTalk(id, talkIndex);
        if (talkData == null)
        {
            isActive = false;
            talkIndex = 0;
            talkPanel.SetActive(isActive);
            objData.checkRead = true;
            return;
        }
        talkName.text = talkData.name;
        
        for (int i = 0; i < (int)Position.max; i++)
        {
            if((int)talkData.position == i)
            {
                talkImage[(int)talkData.position].color = Color.white;
            }
            else
            {
                talkImage[i].color = Color.gray;
            }
        }
        talkImage[(int)talkData.position].sprite = talkData.sprite;
        talkText.text = talkData.talkContents;
        isActive = true;
        talkIndex++;
    }
}