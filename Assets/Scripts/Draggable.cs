using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IDropHandler,IBeginDragHandler
{
    public DropPlayer dp;
    public bool locked;
    Vector3 startPosition;

    void Awake()
    {
        locked = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((dp != null && dp.wait) || locked)
        {
            return;
        }
        startPosition = transform.position;
        this.transform.localScale = new Vector3(2,2,1);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if((dp != null && dp.wait) || locked)
        {
            return;
        }
        Vector3 pos = Camera.main.ScreenToWorldPoint(eventData.position);
        this.transform.position = new Vector3(pos.x, pos.y, -1);
        //Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        //this.transform.position = new Vector3(pos.x, pos.y, -1);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if ((dp != null && dp.wait) || locked)
        {
            return;
        }
        this.transform.localScale = new Vector3(1,1,1);;
        if(dp != null)
        {
            dp.Drop(this.gameObject);
        }
    }

    public void sendToStart()
    {
        this.transform.position = startPosition;
    }
}
