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

    public Battle Enemy;
    public void EnemyAI()
    {
        int RandomValue = UnityEngine.Random.Range(0, 3);

        switch (RandomValue)
        {
            case 0:
                Debug.Log("Enemy Attack!");
                break;
            case 1:
                Enemy.Recover(10);
                break;
            case 2:
                Enemy.ShieldUp(5);
                break;
            default:
                break;
        }

}
}
