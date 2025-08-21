using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    int turnValue;

    public bool playerTurn = true;

    public void TurnChange()
    {
        playerTurn = !playerTurn;

        EnemyTurn();
    }

    private void EnemyTurn()
    {
        EnemyAI();
        playerTurn = true;
    }

    public Battle player;
    public Battle Enemy;
    public void EnemyAI()
    {
        int RandomValue = UnityEngine.Random.Range(0, 3);
        //Debug.Log($"랜덤 값의 정확성 확인 {RandomValue}");

        switch (RandomValue)
        {
            case 0:
                Enemy.Attack(player);
                break;
            case 1:
                Enemy.Recover(5);
                break;
            case 2:
                Enemy.ShieldUp(1);
                break;
            default:
                break;
        }

}
}
