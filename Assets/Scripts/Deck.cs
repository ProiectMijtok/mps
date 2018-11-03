using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    List<int> cardIds;

    // Use this for initialization
    void Awake()
    {
        Populate();
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
