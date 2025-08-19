using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    int turnValue;

    bool playerTurn = true;

    public void TurnChange()
    {
        playerTurn = !playerTurn;
    }
}
