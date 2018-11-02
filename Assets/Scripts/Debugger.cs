using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour {

    // Use this for initialization
    public GameObject card;
    CardModel cardModel;
    int cardIndex = 1;

	void Awake()
    {
        cardModel = GetComponent<CardModel>();
    }

    void OnGui()
    {
        
        if(GUI.Button(new Rect(-19, -43, 100,28), "Hit me!"))
        {
            if(cardIndex == 62)
            {
                cardIndex = 1;
            }
            cardModel.setSprite(cardIndex);
            cardIndex++;
        }
    }
}
