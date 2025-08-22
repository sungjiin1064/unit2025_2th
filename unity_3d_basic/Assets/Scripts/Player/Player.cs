using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 플레이어의 기능을 구현하는 것이 목표입니다.
// 전투와 관련된 요소를 정의합니다.

// 직렬화(Serialized) : 우리가 직접 정의한 클래스 정보를 유니티에서 읽어올 수 없기 떄문에  유니티 인스팩터창에 노출할 수 없다.
// 유니티가 우리가 정의한 정보를 읽을 수 있도록 조치를 취하면 된다.

public class Player : Battle
{
    public override void Attack(Battle other)
    {
        other.TakeDamage(this); // (직접 호출은 안 쓰게 될 수도 있지만 호환성 유지)
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
