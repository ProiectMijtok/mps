using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceCard : MonoBehaviour {

    public int playerId;
    public bool chosen;
    public ChoosePile pile;
	// Update is called once per frame
    void Start()
    {
        //playerId = GetComponent<CardModel>().playerId;
    }

	void OnMouseDown() {
        this.transform.localScale = new Vector3(0, 0, 0);
        chosen = true;
        pile.cardChosen(this);
	}
}
