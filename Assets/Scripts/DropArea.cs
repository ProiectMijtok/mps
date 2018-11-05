using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour {

    internal GameObject card;
    public bool hasCard;
    public int areaType;

    void Start()
    {
        hasCard = false;
    }

	// Use this for initialization
	public void Accept (GameObject o) {
        o.transform.position = this.transform.position;
        o.GetComponent<Draggable>().locked = true;
        hasCard = true;
        card = o;
        CardModel c = o.GetComponent<CardModel>();
        if(c != null)
            c.area = this;
	}

    public void Accept(CardModel o)
    {
        o.transform.position = this.transform.position;
        o.GetComponent<Draggable>().locked = true;
        hasCard = true;
        //card = o;
        //
        o.area = this;
    }

    public void reset()
    {
        hasCard = false;
        Destroy(card);
    }

    /*internal void free()
    {
        DropPlayer dp = GetComponentInParent<DropPlayer>();
        dp.remove(this);
    }*/
}
