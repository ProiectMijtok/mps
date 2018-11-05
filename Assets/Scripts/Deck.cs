using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public int player;
    public int limit;
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

    public void addCard(int id, GameMaster gm)
    {
        cardIds.Add(id);
        addedPlayers++;
        if(addedPlayers == limit)
            GetComponent<DView>().ShowPlayers(player, gm);
    }

    public IEnumerable<int> getCards()
    {
        foreach(int i in cardIds)
        {
            yield return i;
        }
    }
}
