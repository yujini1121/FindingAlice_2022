using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClockTouchAndDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Vector3 dragStartPos;
    [SerializeField] Vector3 posToDrag;


    // Update is called once per frame
    void Update()
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPos = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        posToDrag = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
