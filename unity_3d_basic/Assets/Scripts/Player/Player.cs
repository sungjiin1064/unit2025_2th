using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �÷��̾��� ����� �����ϴ� ���� ��ǥ�Դϴ�.
// ������ ���õ� ��Ҹ� �����մϴ�.

// ����ȭ(Serialized) : �츮�� ���� ������ Ŭ���� ������ ����Ƽ���� �о�� �� ���� ������  ����Ƽ �ν�����â�� ������ �� ����.
// ����Ƽ�� �츮�� ������ ������ ���� �� �ֵ��� ��ġ�� ���ϸ� �ȴ�.

public class Player : Battle
{
    public override void Attack(Battle other)
    {
        if (!battleManager.playerTurn) return;

        other.TakeDamage(this);

        battleManager.TurnChange();
    }

    public override void Recover(int amount)
    {
        if (!battleManager.playerTurn) return;

        base.Recover(amount);

        battleManager.TurnChange();
    }

    public override void ShieldUp(int amount)
    {
        if (!battleManager.playerTurn) return;

        base.ShieldUp(amount);

        battleManager.TurnChange();
    }
}
