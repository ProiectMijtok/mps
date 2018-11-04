using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public int player;
    List<int> cardIds;
    public bool newPlayerAdded;
    private int addedPlayers;

    // Use this for initialization
    void Awake()
    {
        addedPlayers = 0;
        //Populate();
        if(cardIds == null)
        {
            cardIds = new List<int>();
        } else
        {
            cardIds.Clear();
        }
    }

    public void addCard(int id)
    {
        cardIds.Add(id);
        addedPlayers++;
        if(addedPlayers == 11)
            GetComponent<DView>().ShowPlayers(player);
    }

    public IEnumerable<int> getCards()
    {
        foreach(int i in cardIds)
        {
            yield return i;
        }
    }

    void Populate()
    {
        if (cardIds == null)
        {
            cardIds = new List<int>();
        }
        else
        {
            cardIds.Clear();
        }

        for (int i = 0; i < 11; i++)
        {
            int id = Random.Range(1, 61);
            while (cardIds.Contains(id))
            {
                id = Random.Range(1, 61);
            }
            cardIds.Add(id);
        }
    }


}
