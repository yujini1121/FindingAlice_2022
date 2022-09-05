using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
