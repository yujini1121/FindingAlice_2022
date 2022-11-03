using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jump_button : MonoBehaviour
{
    public void InputJumpBtn()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).fingerId != iTouch.jumpId)
            {
                GameObject.FindWithTag("Player").SendMessage("Jump");
            }
        }
    }
}
