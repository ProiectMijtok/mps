using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Functional : MonoBehaviour {

    public Image image;
    int id;

    public void set(int id)
    {
        this.id = id;
        image.sprite = Resources.Load<Sprite>(id.ToString());
    }

    public void action(GameMaster gm)
    {
        switch (id)
        {
            case 1:
                redCard(gm);
                break;
            case 2:
                rain(gm);
                break;
            case 3:
                yellowCard(gm);
                break;
            case 4:
                anthem(gm);
                break;
            case 5:
                mascot(gm);
                break;
            case 6:
                energyDrink(gm);
                break;
            case 7:
                change(gm);
                break;
            case 8:
                foul(gm);
                break;
        }
    }
    
    void redCard(GameMaster gm)
    {
        gm.redCardCalled();
    }

    void rain(GameMaster gm)
    {
        gm.endRound(1);
        gm.endRound(2);
    }

    void yellowCard(GameMaster gm)
    {
        gm.yellowCardCalled();
    }

    void anthem(GameMaster gm)
    {
        gm.anthem();
    }

    void mascot(GameMaster gm)
    {
        gm.mascot();
    }

    void energyDrink(GameMaster gm)
    {
        gm.energyDrink();
    }

    void change(GameMaster gm)
    {
        gm.change();
    }

    void foul(GameMaster gm)
    {
        gm.foul();
    }
    
}
