using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlayer : MonoBehaviour
{
    const int DEFENCE = 1;
    const int MIDFIELD = 2;
    const int ATTACK = 3;

    public bool wait;
    public List<DropArea> dropAreas;
    public int playerAttack;
    public int playerDefence;
    GameMaster gm;

    void Awake()
    {
        playerAttack = 0;
        playerDefence = 0;
    }

    internal void reset(GameMaster g)
    {
        gm = g;
        wait = false;
        this.playerAttack = 0;
        this.playerDefence = 0;
    }

    /*public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");
        float minDist = 99999;
        DropArea minArea = null;
        foreach(DropArea a in dropAreas)
        {
            float distance = Vector3.Distance(a.transform.position, eventData.position);
            if(distance < minDist)
            {
                minDist = distance;
                minArea = a;
            }
        }
        minArea.Accept(eventData.selectedObject);
    }*/

    public void Drop(GameObject o)
    {
        float minDist = 99999;
        DropArea minArea = null;
        foreach (DropArea a in dropAreas)
        {
            float distance = Vector3.Distance(a.transform.position, o.transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                minArea = a;
            }
        }

        if (minDist < 4)
        {
            minArea.Accept(o);
            CardModel c = o.GetComponent<CardModel>();
            switch (minArea.areaType)
            {
                case DEFENCE:
                    playerDefence += c.def;
                    Debug.Log("YUYUYU " + playerDefence);
                    break;
                case ATTACK:
                    playerAttack += c.at;
                    break;
                case MIDFIELD:
                    playerDefence += c.def;
                    playerAttack += c.at;
                    break;
                default:
                    break;

            }
            gm.turnDone();
        } else
        {
            o.GetComponent<Draggable>().sendToStart();
        }
    }
}
