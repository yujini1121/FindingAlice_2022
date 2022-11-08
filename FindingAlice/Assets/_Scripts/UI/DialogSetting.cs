using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSetting : MonoBehaviour
{
    // 실행시 실행 디바이스의 길이를 가져와서 dialogue의 height의 길이를 맞춤.
    [SerializeField] GameObject dialogue;
    private void Start()
    {
        float dialHeight = Screen.height;
        dialogue.GetComponent<RectTransform>().sizeDelta = new Vector2(dialogue.GetComponent<RectTransform>().rect.width, Screen.height);
    }
}
