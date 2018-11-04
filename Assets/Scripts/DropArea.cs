using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour {

    public int areaType;

	// Use this for initialization
	public void Accept (GameObject o) {
        o.transform.position = this.transform.position;
        o.GetComponent<Draggable>().locked = true;
	}
}
