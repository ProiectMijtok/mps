using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Deck))]
public class DView : MonoBehaviour
{
    Deck deck;

    public Vector3 start;
    public Vector3 start1;
    public Vector3 startf1;
    public Vector3 start2;
    public Vector3 startf2;
    public float cardOffset;
    public GameObject cardPrefab;
    int limit;

    void Awake()
    {
        deck = GetComponent<Deck>();
        //ShowPlayers();
        start1 = new Vector3(6.435f, -8.355f, -3);
        start2 = new Vector3(6.435f, 8.255f, -3);
        startf1 = new Vector3(7.11f, -2.67f, -3);
        startf2 = new Vector3(7.11f, 2.7f, -3);

    }

    public void ShowPlayers(int player, GameMaster gm)
    {
        double cardOffset = 1.565;
        Vector3 reset = new Vector3(0,0,0);

        if (player == 1) {
            if (cardPrefab.GetComponent<CardModel>() != null)
            {
                start = start1;
                reset = new Vector3((float)cardOffset, (float)-2.225);
                limit = 6;
            } else if(cardPrefab.GetComponent<Functional>() != null)
            {
                start = startf1;
                reset = new Vector3(-(float)cardOffset/2, (float)-2.225);
                limit = 2;
            }
        }
        else {
            if (cardPrefab.GetComponent<CardModel>() != null)
            {
                start = start2;
                reset = new Vector3((float)cardOffset, (float)2.225);
                limit = 6;
            }
            else if (cardPrefab.GetComponent<Functional>() != null)
            {
                start = startf2;
                reset = new Vector3(-(float)cardOffset/2, (float)2.225);
                limit = 2;
            }
        }
        int cardCount = 0;
        
        double co = 0;
        foreach (int i in deck.getCards())
        {
            GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
            Vector3 temp = start + new Vector3((float)co, 0f);
            cardCopy.transform.position = temp;
            cardCount++;
            CardModel card = cardCopy.GetComponent<CardModel>();
            if (card != null)
                card.setSprite(i);
            else
            {
                Functional fct = cardCopy.GetComponent<Functional>();
                fct.set(i);
            }
            co += cardOffset;
            if(cardCount == limit)
            {
                co = 0;
                start = start + reset;
            }
        }
    }
}
