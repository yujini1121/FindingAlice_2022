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
#if UNITY_ANDROID
            for (int touch = 0; touch < Input.touchCount; touch++)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    if (objData == null)
                        return;
                    Talk(objData.id);
                }
            }
#elif UNITY_EDITOR_WIN 
            if (Input.GetMouseButtonDown(0))
            {
                if (objData == null)
                    return;
                Talk(objData.id);
            }
#endif
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
            if (talkData.sprite != null)
            {
                RectTransform r = (RectTransform)talkImage[i].transform;
                r.sizeDelta = new Vector2(talkData.sprite.rect.width, talkData.sprite.rect.height);
            }
            if(i == (int)talkData.position)
            {
                talkImage[i].color = Color.white;
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