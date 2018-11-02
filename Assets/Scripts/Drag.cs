using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drag : MonoBehaviour {
    public Image img;
    public string player;

    void Start()
    {
        img = GetComponent<Image>();
        //img.sprite = Resources.Load<Sprite>(player);
        //Debug.Log(img.sprite.ToString());
    }
}
