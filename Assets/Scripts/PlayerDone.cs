using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDone : MonoBehaviour {

    GameMaster gm;
    int player;

    public void reset(GameMaster _gm, int p)
    {
        gm = _gm;
        player = p;
    }

    void OnMouseDown()
    {
        if (player == 1 && gm.p1.wait ||
            player == 2 && gm.p2.wait)
            return;
        gm.endRound(player);
    }
}
