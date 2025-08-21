using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Battle
{
    public override void Attack(Battle other)
    {
        if(battleManager.playerTurn) return;

        other.TakeDamage(this);

        Debug.Log("Monster Attack!");
    }

    public override void Recover(int amount)
    {
        if (battleManager.playerTurn) return;

        base.Recover(amount);
    }

    public override void ShieldUp(int amount)
    {
        if (battleManager.playerTurn) return;

        base.ShieldUp(amount);
    }
}
