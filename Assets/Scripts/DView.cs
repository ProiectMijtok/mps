using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Deck))]
public class DView : MonoBehaviour
{
    Deck deck;

    public Vector3 start;
    public Vector3 start1;
    public Vector3 start2;
    public float cardOffset;
    public GameObject cardPrefab;

    void Awake()
    {
        deck = GetComponent<Deck>();
        //ShowPlayers();
        start1 = new Vector3(6.435f, -8.355f, -3);
        start2 = new Vector3(6.435f, 8.255f, -3);

    }

    public void ShowPlayers(int player)
    {
        double cardOffset = 1.565;
        Vector3 reset;

        if (player == 1) {
            start = start1;
            reset = new Vector3((float)cardOffset, (float)-2.225);
        }
        else {
            start = start2;
            reset = new Vector3((float)cardOffset, (float)2.225);
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
            card.setSprite(i);
            co += cardOffset;
            if(cardCount == 6)
            {
                co = 0;
                start = start + reset;
            }
        }
    }

    void Updat()
    {
        /*if(deck.newPlayerAdded)
        {

            int cardCount = 0;
            foreach (int i in deck.getCards())
            {
                float co = cardOffset * cardCount;
                GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
                Vector3 temp = start + new Vector3(co, 0f);
                cardCopy.transform.position = temp;
                cardCount++;
                CardModel card = cardCopy.GetComponent<CardModel>();
                card.setSprite(i);
            }
            deck.newPlayerAdded = false;
        }*/
    }


}
