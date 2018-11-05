using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public static bool isRedCard;
    public static bool isChange;
    public static bool wasChange;
    public static bool isFoul;
    public ChoosePile player1;
    DropPlayer affected;
    DropPlayer not_affected;
    DropPlayer affectedf;
    DropPlayer not_affectedf;
    int anthemCount;

    internal void redCardCalled()
    {
        if(p1.wait)
        {
            affected = p1;
            affectedf = p1fct;
            not_affected = p2;
            not_affectedf = p2fct;
        } else
        {
            affected = p2;
            affectedf = p2fct;
            not_affected = p1;
            not_affectedf = p1fct;
        }
        p1.wait = true;
        p2.wait = true;
        p1fct.wait = true;
        p2fct.wait = true;
        redCardActive = true;
        isRedCard = true;
    }

    internal void yellowCardCalled()
    {
        if (p1.wait)
        {
            affected = p1;
            affectedf = p1fct;
            not_affected = p2;
            not_affectedf = p2fct;
        }
        else
        {
            affected = p2;
            affectedf = p2fct;
            not_affected = p1;
            not_affectedf = p1fct;
        }
        p1.wait = true;
        p2.wait = true;
        p1fct.wait = true;
        p2fct.wait = true;
        yellowCardActive = true;
    }

    internal void foul()
    {
        if (p1.wait)
        {
            affected = p1;
            affectedf = p1fct;
            not_affected = p2;
            not_affectedf = p2fct;
        }
        else
        {
            affected = p2;
            affectedf = p2fct;
            not_affected = p1;
            not_affectedf = p1fct;
        }
        p1.wait = true;
        p2.wait = true;
        p1fct.wait = true;
        p2fct.wait = true;
        isFoul = true;
    }

    public void anthem()
    {
        anthemCount = 2;
    }

    public void mascot()
    {
        int i = UnityEngine.Random.Range(1, 3);
        DropPlayer dpChosenByGodds;
        if(i == 1 && p1.hasCards)
        {
            dpChosenByGodds = p1;
        } else if(p2.hasCards)
        {
            dpChosenByGodds = p2;
        } else
        {
            turnDone();
            return;
        }

        int size = 9;
        DropArea da = dpChosenByGodds.dropAreas[UnityEngine.Random.Range(1, size)];
        while(!da.hasCard)
        {
            da = dpChosenByGodds.dropAreas[UnityEngine.Random.Range(1, size)];
        }

        i = UnityEngine.Random.Range(1, 3);
        int cd=0, ca=0;
        if(i == 1)
        {
            da.card.GetComponent<CardModel>().at += 2;
            da.card.GetComponent<CardModel>().attack.text += " +2";
            ca = 2;
        } else
        {
            da.card.GetComponent<CardModel>().def += 2;
            da.card.GetComponent<CardModel>().defence.text += " +2";
            cd = 2;
        }
        dpChosenByGodds.changed(ca, cd, da);
        turnDone();       
    }

    internal void change()
    {
        if (p1.wait)
        {
            affected = p1;
            affectedf = p1fct;
            not_affected = p2;
            not_affectedf = p2fct;
        }
        else
        {
            affected = p2;
            affectedf = p2fct;
            not_affected = p1;
            not_affectedf = p1fct;
        }
        p1.wait = true;
        p2.wait = true;
        p1fct.wait = true;
        p2fct.wait = true;
        isChange = true;
        wasChange = false;
    }
    public void energyDrink ()
    {
        DropPlayer active;
        if (p1.wait)
        {
            active = p2;
        } else
        {
            active = p1;
        }

        DropArea minAt = null;
        int minAtVal = 10;
        foreach (DropArea da in active.dropAreas)
        {
            if(da.hasCard)
            {
                if(da.card.GetComponent<CardModel>().at < minAtVal)
                {
                    minAt = da;
                    minAtVal = da.card.GetComponent<CardModel>().at;
                }
            }
        }

        if(minAt == null)
        {
            turnDone();
            return;
        }

        minAt.card.GetComponent<CardModel>().at += 2;
        minAt.card.GetComponent<CardModel>().attack.text += " +2";
        active.changed(2, 0, minAt);
        turnDone();
    }

    public ChoosePile player2;
    public ChoosePile p1funct;
    public ChoosePile p2funct;
    public DropPlayer p1;
    public DropPlayer p2;
    public DropPlayer p1fct;
    public DropPlayer p2fct;
    public bool player1ChoseCards;
    public bool player1ChoseFunctionals;
    public bool player2ChoseFunctionals;
    public PlayerDone p1EndRound;
    public PlayerDone p2EndRound;
    public Text player1Score;
    public Text player2Score;
    SpriteRenderer rnd;
    int scoreP1;
    int scoreP2;
    int curAtP1;
    int curAtP2;
    int curDefP1;
    int curDefP2;
    bool otherIsDone;
    internal bool redCardActive;
    public static bool yellowCardActive;

    void Start()
    {
        rnd = GetComponent<SpriteRenderer>();
        rnd.color = new Color(0.2f,0.2f,0.2f);
        foreach(SpriteRenderer r in GetComponentsInChildren<SpriteRenderer>())
        {
            if(r != null)
            {
                r.color = new Color(0.2f, 0.2f, 0.2f);
            }
        }
        player1ChoseCards = false;
        player1.player = 1;
        player1.AwakeInMaster(new Vector3(-9, 1, -3), 20);
        p1EndRound.reset(this, 1);
        p2EndRound.reset(this, 2);
        anthemCount = 0;
        otherIsDone = false;
        scoreP1 = 0;
        scoreP2 = 0;
        player1Score.text = "0";
        player2Score.text = "0";
    }

    public void playerDone()
    {
        if (!player1ChoseCards)
        {
            player2.player = 2;
            player2.AwakeInMaster(new Vector3(-9, 8.7f, -3), 20);
            player1ChoseCards = true;
        }
        else
        {
            if (!player1ChoseFunctionals)
            {
                p1funct.player = 1;
                p1funct.AwakeFunctionals(new Vector3(-9, 1, -3), 10, this);
                player1ChoseFunctionals = true;
            }
            else if (!player2ChoseFunctionals)
            {
                p2funct.player = 2;
                p2funct.AwakeFunctionals(new Vector3(-9, 8.7f, -3), 10, this);
                player2ChoseFunctionals = true;
            }
            else
            {
                rnd.color = new Color(1, 1, 1);
                foreach (SpriteRenderer r in GetComponentsInChildren<SpriteRenderer>())
                {
                    if (r != null)
                    {
                        r.color = new Color(1, 1, 1);
                    }
                }
                p1.reset(this);
                p2.reset(this);
                p1fct.reset(this);
                p2fct.reset(this);
                p2.wait = true;
                p2fct.wait = true;
            }
        }
    }

    internal void turnDone()
    {
        if(isFoul)
        {
            isFoul = false;
            not_affectedf.wait = false;
            not_affected.wait = false;
            affected.wait = true;
            affectedf.wait = true;
        }
        if(wasChange)
        {
            wasChange = false;
            not_affectedf.wait = false;
            not_affected.wait = false;
            affected.wait = true;
            affectedf.wait = true;
        }

        if(redCardActive)
        {
            redCardActive = false;
            isRedCard = false;
            not_affectedf.wait = false;
            not_affected.wait = false;
            affected.wait = true;
            affectedf.wait = true;
        }
        else if(yellowCardActive)
        {
            yellowCardActive = false;
            not_affectedf.wait = false;
            not_affected.wait = false;
            affected.wait = true;
            affectedf.wait = true;
        }

        if(anthemCount > 0)
        {
            anthemCount -= 1;
            return;
        }

        if (otherIsDone)
            return;

        if(p1.wait)
        {
            p1.wait = false;
            p1fct.wait = false;
            p2fct.wait = true;
            p2.wait = true;
            return;
        }
        p1.wait = true;
        p1fct.wait = true;
        p2fct.wait = false;
        p2.wait = false;   
    }

    public void endRound(int p)
    {
        if(p == 1)
        {
            curAtP1 = p1.playerAttack;
            curDefP1 = p1.playerDefence;
        }
        else
        {
            curAtP2 = p2.playerAttack;
            curDefP2 = p2.playerDefence;
        }

        if(otherIsDone)
        {
            decideWinner();
            resetAll();
        } else
        {
            turnDone();
            otherIsDone = true;
        }
    }

    private void resetAll()
    {
        p1.reset(this);
        p2.reset(this);
        p1fct.reset(this);
        p2fct.reset(this);
        otherIsDone = false;

        if(scoreP1 + scoreP2 == 1)
        {
            p1.wait = true;
            p2.wait = false;
        }
        else
        {
            p1.wait = false;
            p2.wait = true;
        }
    }

    void decideWinner()
    {
        int d1 = curAtP1 - curDefP2;
        int d2 = curAtP2 - curDefP1;

        if(d1 > d2)
        {
            scoreP1 += 1;
        }
        else
        {
            scoreP2 += 1;
        }

        player1Score.text = scoreP1 + "";
        player2Score.text = scoreP2 + "";

        if(scoreP1 + scoreP2 == 3)
        {
            //TODO - final 3 runde
        }
    }
}
