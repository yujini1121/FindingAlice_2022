using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jump_button : MonoBehaviour
{
    int jumpId = -1;
    [SerializeField] RectTransform jumpRect;
    public void InputJumpBtn()
    {
#if false
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).fingerId != iTouch.jumpId)
            {
                GameObject.FindWithTag("Player").SendMessage("Jump");
            }
        }
#else
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                if (jumpId == -1 && iTouch.CheckRect(jumpRect, t.position))
                    jumpId = Input.GetTouch(i).fingerId;
            }
            else if (t.phase == TouchPhase.Ended)
            {
                if (i == jumpId)
                    jumpId = -1;
            }
        }
#endif
    }
}
