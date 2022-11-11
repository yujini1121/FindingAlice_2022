using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iTouch : MonoBehaviour
{
    public List<int> touches = new List<int>();

    public static int joystickId = -1, clockId = -1, jumpId = -1;
    [SerializeField]RectTransform jsAreaRect;
    [SerializeField] RectTransform jumpRect;
    public static bool checkEvent = false;

    public bool checkClockbtn = false;

    private void Awake()
    {
        Input.multiTouchEnabled = true;
        checkEvent = false;
    }
#if true
    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                if (checkEvent)
                    return;
                if (joystickId == -1 && CheckRect(jsAreaRect, t.position))
                    joystickId = Input.GetTouch(i).fingerId;
                if (jumpId == -1 && CheckRect(jumpRect, t.position))
                    jumpId = Input.GetTouch(i).fingerId;
                //else if (clockId == -1 && t.position.x > Screen.width / 2)
                else if (clockId == -1 && checkClockbtn)
                    clockId = Input.GetTouch(i).fingerId;

            }
            else if (t.phase == TouchPhase.Ended)
            {
                if (i == joystickId)
                    joystickId = -1;
                if (i == jumpId)
                    jumpId = -1;
                if (i == clockId)
                    clockId = -1;
            }
        }
        Debug.Log($"jsId : {joystickId}\n\tjumpId : {jumpId}\n\tclockId : {clockId}");
    }
#else
    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                touches.Add();
            }
            else if (t.phase == TouchPhase.Ended)
            {
                touches.RemoveAt(touches.IndexOf(thisTouch));
            }
            else if (t.phase == TouchPhase.Moved)
            {
            }
        }
    }
#endif
    public static bool CheckRect(RectTransform rt, Vector2 touchPos)
    {
        float posX = rt.rect.width * rt.lossyScale.x * 0.5f + 10;
        float posY = rt.rect.height * rt.lossyScale.y * 0.5f + 10;
        return (touchPos.x > (rt.transform.position.x - posX)) &&
            (touchPos.x < (rt.transform.position.x + posX)) &&
            (touchPos.y > (rt.transform.position.y - posY)) &&
            (touchPos.y < (rt.transform.position.y + posY));
    }

    public void CheckTouch(bool check)
    {
        checkClockbtn = check;
    }

}
