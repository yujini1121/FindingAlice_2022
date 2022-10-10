using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

#if UNITY_ANDROID
public class ClockTouchAndDrag : MonoBehaviour
{
    [SerializeField] Vector3 dragStartPos = Vector3.zero;
    [SerializeField] Vector3 posToDrag = Vector3.zero;

    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).fingerId == iTouch.clockId)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Stationary || Input.GetTouch(i).phase == TouchPhase.Moved)
                {
                    if (ClockManager.C.clockCounter > 0 && ClockManager.C.CS == ClockState.idle)
                    {
                        ClockManager.C.CS = ClockState.shoot;
                        ClockManager.C.clockPreparatoryAction();
                        dragStartPos = Input.GetTouch(i).position;
                    }
                    if (ClockManager.C.CS == ClockState.shoot || ClockManager.C.CS == ClockState.shootMaximum)
                    {
                        posToDrag = Input.GetTouch(i).position;
                        ClockManager.C.touchAndDragPos = (posToDrag - dragStartPos).normalized;
                    }
                }
            }
        }
        if (iTouch.clockId == -1)
        {
            if (ClockManager.C.CS == ClockState.shoot || ClockManager.C.CS == ClockState.shootMaximum)
            {
                ClockManager.C.CS = ClockState.follow;
                ClockManager.C.clockFollowAction();
                dragStartPos = Vector3.zero;
                posToDrag = Vector3.zero;
            }
        }
    }
}
#elif UNITY_EDITOR_WIN
public class ClockTouchAndDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Vector3 dragStartPos = Vector3.zero;
    [SerializeField] Vector3 posToDrag = Vector3.zero;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (ClockManager.C.clockCounter > 0 && ClockManager.C.CS == ClockState.idle)
        {
            ClockManager.C.CS = ClockState.shoot;
            ClockManager.C.clockPreparatoryAction();
            dragStartPos = Input.mousePosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (ClockManager.C.CS == ClockState.shoot || ClockManager.C.CS == ClockState.shootMaximum)
        {
            posToDrag = Input.mousePosition;
            ClockManager.C.touchAndDragPos = (posToDrag - dragStartPos).normalized;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (ClockManager.C.CS == ClockState.shoot || ClockManager.C.CS == ClockState.shootMaximum)
        {
            ClockManager.C.CS = ClockState.follow;
            ClockManager.C.clockFollowAction();
            dragStartPos = Vector3.zero;
            posToDrag = Vector3.zero;
        }
    }
}
#endif

