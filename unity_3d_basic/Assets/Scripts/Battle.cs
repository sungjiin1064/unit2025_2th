using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BattleEntity
{
    public int HP;
    public int ATK;
    public int DEF;
    public string AttackType;
    public string NAME;

    public BattleEntity() { }
    public BattleEntity(int hp, int atk)
    {
        HP = hp;
        ATK = atk;
    }
    [SerializeField]
    public BattleEntity(int hp, int atk, int def)
    {
        HP = hp;
        ATK = atk;
        DEF = def;
    }
}

[System.Serializable]
public class BattleUI
{
    public Image HpBar;
    public TextMeshProUGUI BattleEntityText;
    public TextMeshProUGUI BattleNameText;
    public TextMeshProUGUI HpText;

    public void SetBattleUI(BattleEntity battleEntity)
    {
        BattleEntityText.SetText($"ATK : {battleEntity.ATK} / DEF : {battleEntity.DEF}");
        BattleNameText.SetText($"{battleEntity.NAME}");
    }
    public void SetHPBar(int current, int max)
    {
        HpBar.fillAmount = (float)current / max;

        float percent = ((float)current / max) * 100;
        HpText.SetText($"{current} / {max} ({percent:F0}%)");
    }
}

public abstract class Battle : MonoBehaviour // �߻� Ŭ����. �ν��Ͻ� �� �� ����(������Ʈ�� ������Ʈ�� ��� �� �� ����).
{
    public BattleEntity battleEntity;
    public BattleUI battleUI;
    public BattleManager battleManager;

    private int currentHP;
    public int CurrentHP
    {
        get { return currentHP; }
        private set
        {
            int clamped = Mathf.Clamp(value, 0, battleEntity.HP);
            if (clamped == currentHP) return;   // ��ȭ ������ �ƹ��͵� �� ��
            currentHP = clamped;

            // HP�� 0�� �Ǵ� ���� ��� Death()
            if (currentHP <= 0)
            {
                Death();
            }
        }
    }

    private void Start()
    {
        //battleEntity = new BattleEntity(playerHP, playerATK, playerDEF);
        Debug.Log($"ATK : {battleEntity.ATK}, DEF : {battleEntity.DEF}");
        battleUI.SetBattleUI(battleEntity);
        CurrentHP = battleEntity.HP;
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    CurrentHP -= 15;
        //    CurrentHP = Mathf.Clamp(CurrentHP, 0, battleEntity.HP);
        //}

        battleUI.SetHPBar(CurrentHP, battleEntity.HP);
    }

    public void TakeDamage(Battle other)
    {
        int FinalDamage = (other.battleEntity.ATK - battleEntity.DEF);
        if (FinalDamage <= 0) FinalDamage = 1;

        CurrentHP -= FinalDamage;       

        BattleManager.Print($"{other.battleEntity.NAME}�� ���� ����! {FinalDamage} ���ظ� ������, ATK�� {other.battleEntity.ATK}�� �Ǿ����ϴ�.");
    }

    public void Death()
    {
        Debug.Log($"����߽��ϴ�. ���� ü�� : {currentHP}");
        battleManager.GameOver(this);
    }
    public abstract void Attack(Battle other);
   
    public virtual void Recover(int amount)
    {     
        CurrentHP += amount;        
    }
    public virtual void ShieldUp(int amount)
    {      
        battleEntity.DEF += amount;
        battleUI.SetBattleUI(battleEntity);        
    }
    public int CalcDamageFrom(Battle attacker)
    {
        int dmg = attacker.battleEntity.ATK - battleEntity.DEF;
        if (dmg <= 0) dmg = 1;
        return dmg;
    }
    public void ApplyDamage(int amount)
    {
        CurrentHP -= amount;
    }

    public void ApplyGuardEffect() // ���� : ������ ��ȿ + DEF+1 + HP+10
    {
        ShieldUp(1);    // DEF +1 �� UI ���� ����(���� �޼���)
        Recover(10);    // HP +10 (���� �޼���)
    }



}
