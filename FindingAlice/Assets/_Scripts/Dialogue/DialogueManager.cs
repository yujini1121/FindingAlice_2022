using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    public GameObject joystick;
    public GameObject jumpButton;
    public Text talkText;
    public Text talkName;
    public Image[] talkImage;
    public GameObject scanObject;
    public int talkIndex;

    public bool isActive = false;

    public ObjData objData;

    string sceanName;
    private void Start()
    {
        sceanName = SceneManager.GetActiveScene().name;
        for (int i = 1; i < 3; i++) {
            if (sceanName == "TutoTalk " + i)
            {
                fade = GameObject.Find("FadeImage");
                Talk(objData.id);
                break;
            }
        }
    }

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
            ClockManager.C.clockReset();
            Talk(objData.id);            
        }
        talkPanel.SetActive(isActive);
        jumpButton.SetActive(!isActive);
        joystick.SetActive(!isActive);
    }

    RectTransform r;
    GameObject fade;
    private void Talk(int id)
    {
        TalkData talkData = talkManager.GetTalk(id, talkIndex);
        if (talkData == null)
        {
            isActive = false;
            talkIndex = 0;
            for (int i = 1; i < 3; i++)
            {
                if (sceanName == "TutoTalk " + i)
                {
                    
                    fade.SetActive(true);
                    break;
                }
            }
            for (int i = 0; i< talkImage.Length; i++)
            {
                talkImage[i].sprite = null;
            }
            talkPanel.SetActive(isActive);
            jumpButton.SetActive(!isActive);
            joystick.SetActive(!isActive);
            objData.checkRead = true;
            return;
        }
        talkName.text = talkData.name;
        
        for (int i = 0; i < (int)Position.max; i++)
        {
            if (talkData.sprite != null)
            {
                if(i == (int)talkData.position)
                {
                    talkImage[i].color = Color.white;
                    r = (RectTransform)talkImage[i].transform;
                    if(talkData.sprite.name == "ParentRabbit")
                    {
                        float ratio = 600 / talkData.sprite.rect.height;
                        r.sizeDelta = new Vector2(talkData.sprite.rect.width * ratio, talkData.sprite.rect.height * ratio);
                    }
                    else
                        r.sizeDelta = new Vector2(talkData.sprite.rect.width, talkData.sprite.rect.height);
                }
                else
                {
                    talkImage[i].color = Color.gray;
                    if (talkImage[i].sprite == null)
                        talkImage[i].color = SetColorAlpha(talkImage[i].color, 0);
                }
            }
            
        }
        talkImage[(int)talkData.position].sprite = talkData.sprite;
        talkText.text = talkData.talkContents;
        isActive = true;
        talkIndex++;
    }
    Color SetColorAlpha(Color c, float a)
    {
        Color color = c;
        Color _color = new Color(color.r, color.g, color.b, a);

        return _color;
    }
}