using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IDropHandler,IBeginDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        this.transform.localScale = new Vector3(2,2,1);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(eventData.position);
        this.transform.position = new Vector3(pos.x, pos.y, -1);
        //Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        //this.transform.position = new Vector3(pos.x, pos.y, -1);
    }

    public void OnDrop(PointerEventData eventData)
    {
        this.transform.localScale = new Vector3(1 ,1,1);
    }
}
