using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iTouch : MonoBehaviour
{
    public static int joystickId = -1, clockId = -1, jumpId = -1;
    [SerializeField]RectTransform jsAreaRect;

    bool checkJump;

    private void Awake()
    {
        Input.multiTouchEnabled = true;
    }

    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                if (joystickId == -1 && CheckRect(jsAreaRect, t.position))
                    joystickId = Input.GetTouch(i).fingerId;
                if (jumpId == -1 && checkJump)
                    jumpId = Input.GetTouch(i).fingerId;
                else if (clockId == -1 && t.position.x > Screen.width / 2)
                    clockId = Input.GetTouch(i).fingerId;

            }
            if (t.phase == TouchPhase.Ended)
            {
                if (joystickId > -1)
                    joystickId = -1;
                if (jumpId > -1)
                    jumpId = -1;
                if (clockId > -1)
                    clockId = -1;
            }
        }
        Debug.Log($"jsId : {joystickId}\n\tjumpId : {jumpId}\n\tclockId : {clockId}");
    }

    public void JumpBtn(bool b)
    {
        checkJump = b;
    }

    private bool CheckRect(RectTransform rt, Vector2 touchPos)
    {
        float posX = rt.localPosition.x * rt.lossyScale.x;
        float posY = rt.localPosition.y * rt.lossyScale.y;
        return (touchPos.x > (rt.transform.position.x - posX)) &&
            (touchPos.x < (rt.transform.position.x + posX)) &&
            (touchPos.y > (rt.transform.position.y - posY)) &&
            (touchPos.y < (rt.transform.position.y + posY));
    }

}
