using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePile : MonoBehaviour {

    public int playersNo;
    public int player;
    Vector3 start;
    Deck deck;
    public GameObject cardPrefab;
    public float cardOffset;
    List<GameObject> cards;
    private int chosenCards;

    //public ChoiceCard[] choiceCards;
    // Use this for initializatio

    void Update()
    {
        
    }

    public void AwakeInMaster(Vector3 s)
    {
        playersNo = 20;
        chosenCards = 0;
        deck = GetComponent<Deck>();
        deck.player = player;
        cards = new List<GameObject>();
        start = s;//new Vector3(-9, 1, -1);
        cardOffset = 3;
        float co = 0;
        List<int> generated = new List<int>();
        int id;

        for (int i = 0; i < playersNo; i++)
        {
            
            GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
            cards.Add(cardCopy);
            Vector3 temp = start + new Vector3(co, 0f);
            cardCopy.transform.position = temp;
            CardModel card = cardCopy.GetComponent<CardModel>();
            cardCopy.GetComponent<ChoiceCard>().pile = this;
            id = Random.Range(1, 60);

            while(generated.Contains(id))
            {
                id = Random.Range(1, 60);
            }

            generated.Add(id);
            card.setSprite(id);
            co += cardOffset;

            if ((i+1) % 5 == 0)
            {
                co = 0;
                start += new Vector3(0, -3);
            }
        }
    }
	
	// Update is called once per frame
	public void cardChosen(ChoiceCard c)
    {
        chosenCards++;
        deck.addCard(c.playerId);
        if(chosenCards == 11)
        {
            foreach(GameObject o in cards)
            {
                Destroy(o);
            }
            GetComponentInParent<GameMaster>().playerDone();
        }
    }
}
