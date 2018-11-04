using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public ChoosePile player1;
    public ChoosePile player2;
    public DropPlayer p1;
    public DropPlayer p2;
    public bool player1ChoseCards;
    public PlayerDone p1EndRound;
    public PlayerDone p2EndRound;
    SpriteRenderer rnd;
    int scoreP1;
    int scoreP2;
    int curAtP1;
    int curAtP2;
    int curDefP1;
    int curDefP2;
    bool otherIsDone;

	void Start()
    {
        rnd = GetComponent<SpriteRenderer>();
        rnd.color = new Color(0.2f,0.2f,0.2f);
        player1ChoseCards = false;
        player1.player = 1;
        player1.AwakeInMaster(new Vector3(-9, 1, -3));
        p1EndRound.reset(this, 1);
        p2EndRound.reset(this, 2);
        otherIsDone = false;
        scoreP1 = 0;
        scoreP2 = 0;
    }

    public void playerDone()
    {
        if (!player1ChoseCards)
        {
            player2.player = 2;
            player2.AwakeInMaster(new Vector3(-9, 8.7f, -3));
            player1ChoseCards = true;
        }
        else
        {
            rnd.color = new Color(1, 1, 1);
            p1.reset(this);
            p2.reset(this);
            //p1.start();
            p2.wait = true;
        }
    }

    internal void turnDone()
    {
        if (otherIsDone)
            return;

        if(p1.wait)
        {
            p1.wait = false;
            p2.wait = true;
            return;
        }
        p1.wait = true;
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
            otherIsDone = true;
            turnDone();
        }
    }

    private void resetAll()
    {
        //TODO - reset board and scores;
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
    }
}
