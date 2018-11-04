using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour {

    GameObject card;
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
	}

    public void reset()
    {
        hasCard = false;
        Destroy(card);
    }
}
