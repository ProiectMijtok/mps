using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    List<int> cardIds;
    System.Random rnd;

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

        for(int i = 0; i < 11; i++)
        {
            int id = rnd.Next(1,2);
            while (!cardIds.Contains(id))
                id = rnd.Next(1, 62);
            cardIds.Add(id);
        }
    }
	// Use this for initialization
	void Start () {
        Populate();
	}

}
