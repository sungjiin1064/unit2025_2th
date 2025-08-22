using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Battle
{
    public override void Attack(Battle other)
    {
        other.TakeDamage(this);
        Debug.Log("Monster Attack!");
    }
    public override void Recover(int amount)
    {
        base.Recover(amount);
    }
    public override void ShieldUp(int amount)
    {
        base.ShieldUp(amount);
    }
}

