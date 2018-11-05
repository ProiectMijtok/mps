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
    List<GameObject> cards;
    GameMaster gm;
    internal bool hasCards;
    GameObject active;
    GameObject sub;

    void Awake()
    {
        playerAttack = 0;
        playerDefence = 0;
    }

    public void addCard(GameObject c)
    {
        this.cards.Add(c);
    }

    internal void reset(GameMaster g)
    {
        this.gm = g;
        wait = false;
        this.playerAttack = 0;
        this.playerDefence = 0;
        active = null;
        sub = null;
        if (cards == null)
            cards = new List<GameObject>();
        else
            destroyCards();
    }

    private void destroyCards()
    {
        /*foreach(GameObject o in cards)
        {
            Destroy(o);
        }
        cards.Clear();*/
        foreach(DropArea a in dropAreas)
        {
            a.reset();
        }
    }

    public void Drop(GameObject o)
    {
        hasCards = true;
        float minDist = 99999;
        DropArea minArea = null;
        foreach (DropArea a in dropAreas)
        {
            if (a.hasCard)
                continue;

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
            Functional a = o.GetComponent<Functional>();
            if(a != null)
            {
                a.action(gm);
                return;
            }
            CardModel c = o.GetComponent<CardModel>();
            switch (minArea.areaType)
            {
                case DEFENCE:
                    playerDefence += c.def;
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

    internal void remove(DropArea da)
    {
        if (da == null)
        {
            gm.turnDone();
            return;
        }

        switch(da.areaType)
        {
            case DEFENCE:
                playerDefence -= da.card.GetComponent<CardModel>().def;
                break;
            case MIDFIELD:
                playerDefence -= da.card.GetComponent<CardModel>().def;
                playerAttack -= da.card.GetComponent<CardModel>().at;
                break;
            case ATTACK:
                playerAttack -= da.card.GetComponent<CardModel>().at;
                break;
        }
        
        if(GameMaster.isRedCard)
        {
            da.reset();
            gm.turnDone();
        }     
    }

    public void changed(int addedAt, int addedDef, DropArea da)
    {
        if (da == null)
        {
            gm.turnDone();
            return;
        }

        switch (da.areaType)
        {
            case DEFENCE:
                playerDefence += addedDef;
                break;
            case MIDFIELD:
                playerDefence += addedDef;
                playerAttack += addedAt;
                break;
            case ATTACK:
                playerAttack += addedAt;
                break;
        }

        if(GameMaster.yellowCardActive || GameMaster.isFoul)
        {
            gm.turnDone();
        }
    }

    void DropOnArea(GameObject o, DropArea a)
    {
        a.Accept(o);
        CardModel c = o.GetComponent<CardModel>();

        switch (a.areaType)
        {
            case DEFENCE:
                playerDefence += c.def;
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
        //c.GetComponent<GameObject>().transform.position = a.GetComponent<GameObject>().transform.position
    }

    public void change(GameObject c)
    {
        if (active == null)
        {
            if (c.GetComponent<CardModel>().area == null)
                return;
            this.active = c;
            return;
        }

        if (c.GetComponent<CardModel>().area != null)
            return;
        sub = c;
        GameMaster.isChange = false;
        GameMaster.wasChange = true;
        Vector3 positionInDeck = sub.transform.position;
        remove(active.GetComponent<CardModel>().area);
        DropOnArea(sub, active.GetComponent<CardModel>().area);
        active.GetComponent<Draggable>().locked = false;
        active.transform.position = positionInDeck;
        gm.turnDone();
        active = null;
        sub = null;
    }
}
