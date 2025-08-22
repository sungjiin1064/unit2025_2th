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
    [SerializeField] Animator animator;

    public override void Attack(Battle other)
    {
        animator.SetTrigger("Attack");
        //other.TakeDamage(this); // (���� ȣ���� �� ���� �� ���� ������ ȣȯ�� ����)
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
