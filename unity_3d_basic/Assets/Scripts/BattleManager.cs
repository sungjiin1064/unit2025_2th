using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 전역 enum
public enum BattleAction
{
    None,
    Attack,
    Guard,
    GuardBreaker
}

public class BattleManager : MonoBehaviour
{
    public Battle player;
    public Battle Enemy;

    private int turnCounter = 0;
    private bool gameOver = false;

    private BattleAction playerChoice = BattleAction.None;
    private BattleAction enemyChoice = BattleAction.None;

    // 버튼 연결
    public void OnPlayerAction_Attack() => OnPlayerAction(BattleAction.Attack);
    public void OnPlayerAction_Guard() => OnPlayerAction(BattleAction.Guard);
    public void OnPlayerAction_GuardBreaker() => OnPlayerAction(BattleAction.GuardBreaker);

    public void OnPlayerAction(BattleAction choice)
    {
        if (playerChoice != BattleAction.None) return; // 중복 입력 방지
        playerChoice = choice;

        // 적 랜덤 선택
        enemyChoice = (BattleAction)UnityEngine.Random.Range(1, 4);

        turnCounter++;
        Print($"==== {turnCounter} 턴 시작 ====");

        ResolveRound();

        // 다음 라운드 준비
        playerChoice = BattleAction.None;
        enemyChoice = BattleAction.None;
    }

    private string ActionKor(BattleAction a)
    {
        if (a == BattleAction.Attack) return "공격";
        if (a == BattleAction.Guard) return "가드";
        if (a == BattleAction.GuardBreaker) return "가드브레이크";
        return "없음";
    }

    private void ResolveRound()
    {
        Print($"플레이어: {ActionKor(playerChoice)}, 몬스터: {ActionKor(enemyChoice)}");

        // 1) 동일 선택
        if (playerChoice == enemyChoice)
        {
            if (playerChoice == BattleAction.Attack)
            {
                int dmgToEnemy = Enemy.CalcDamageFrom(player);
                int dmgToPlayer = player.CalcDamageFrom(Enemy);

                Enemy.ApplyDamage(dmgToEnemy);
                player.ApplyDamage(dmgToPlayer);

                player.battleEntity.ATK += 1;
                Enemy.battleEntity.ATK += 1;
                player.battleUI.SetBattleUI(player.battleEntity);
                Enemy.battleUI.SetBattleUI(Enemy.battleEntity);

                Print($"둘 다 공격! 플레이어 {dmgToEnemy} 피해 주고, {dmgToPlayer} 피해 받음!");
            }
            else
            {
                player.ApplyDamage(10);
                Enemy.ApplyDamage(10);
                Print($"둘 다 {ActionKor(playerChoice)}! HP가 10씩 감소!");
            }
        }

        // 2) 서로 다른 선택
        else if (playerChoice == BattleAction.Attack && enemyChoice == BattleAction.Guard)
        {
            Enemy.ApplyGuardEffect();
            Print("플레이어 공격, 몬스터 가드!");
        }
        else if (playerChoice == BattleAction.Guard && enemyChoice == BattleAction.Attack)
        {
            player.ApplyGuardEffect();
            Print("플레이어 가드, 몬스터 공격!");
        }
        else if (playerChoice == BattleAction.Guard && enemyChoice == BattleAction.GuardBreaker)
        {
            int dmg = Mathf.Max(1, Enemy.battleEntity.ATK * 2 - player.battleEntity.DEF);
            player.ApplyDamage(dmg);
            Print($"플레이어 가드, 몬스터 브레이크! 플레이어 {dmg} 피해!");
        }
        else if (playerChoice == BattleAction.GuardBreaker && enemyChoice == BattleAction.Guard)
        {
            int dmg = Mathf.Max(1, player.battleEntity.ATK * 2 - Enemy.battleEntity.DEF);
            Enemy.ApplyDamage(dmg);
            Print($"플레이어 브레이크, 몬스터 가드! 몬스터 {dmg} 피해!");
        }
        else if (playerChoice == BattleAction.Attack && enemyChoice == BattleAction.GuardBreaker)
        {
            int dmg = Enemy.CalcDamageFrom(player);
            Enemy.ApplyDamage(dmg);

            player.battleEntity.ATK++;
            player.battleUI.SetBattleUI(player.battleEntity);

            Print($"플레이어 공격 ! 몬스터 {dmg} 피해! (ATK {player.battleEntity.ATK})");
        }
        else if (playerChoice == BattleAction.GuardBreaker && enemyChoice == BattleAction.Attack)
        {
            int dmg = player.CalcDamageFrom(Enemy);
            player.ApplyDamage(dmg);

            Enemy.battleEntity.ATK++;
            Enemy.battleUI.SetBattleUI(Enemy.battleEntity);

            Print($"몬스터 공격 ! 플레이어 {dmg} 피해! (ATK {Enemy.battleEntity.ATK})");
        }

        // ✅ 전투 처리 끝난 후 항상 게임오버 체크
        CheckGameOver();
    }

    public static void Print(string msg)
    {
        Debug.Log(msg);
        if (CombatLogUI.I != null)
        {
            CombatLogUI.I.Log(msg);
        }
    }

    public void GameOver(Battle loser)
    {
        if (gameOver) return;
        gameOver = true;

        string winner = (loser == player) ? "몬스터" : "플레이어";
        Print($"게임 종료!");

        // 👉 게임 멈추기
        Time.timeScale = 0;
    }

    public void CheckGameOver()
    {
        if (player.CurrentHP <= 0)
        {
            GameOver(player);
        }
        else if (Enemy.CurrentHP <= 0)
        {
            GameOver(Enemy);
        }
    }
}
