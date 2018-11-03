using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Deck))]
public class DView : MonoBehaviour
{
    Deck deck;

    public Vector3 start;
    public float cardOffset;
    public GameObject cardPrefab;

    void Start()
    {
        deck = GetComponent<Deck>();
        ShowPlayers();
    }

    void ShowPlayers()
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
    }


}
