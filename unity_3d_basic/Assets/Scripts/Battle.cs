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
        if (BattleEntityText != null)
            BattleEntityText.SetText($"ATK : {battleEntity.ATK} / DEF : {battleEntity.DEF}");
        if (BattleNameText != null)
            BattleNameText.SetText($"{battleEntity.NAME}");
    }
    public void SetHPBar(int current, int max)
    {
        if (HpBar != null)
            HpBar.fillAmount = max > 0 ? (float)current / max : 0f;

        if (HpText != null)
        {
            float percent = max > 0 ? ((float)current / max) * 100f : 0f;
            HpText.SetText($"{current} / {max} ({percent:F0}%)");
        }
    }
}

public abstract class Battle : MonoBehaviour
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
            int clamped = Mathf.Clamp(value, 0, battleEntity != null ? battleEntity.HP : value);
            if (clamped == currentHP) return;

            currentHP = clamped;
                        
            if (currentHP <= 0)
            {
                Death();
            }
        }
    }

    private void Start()
    {
        if (battleUI != null && battleEntity != null)
        {
            battleUI.SetBattleUI(battleEntity);
        }
        if (battleEntity != null)
            CurrentHP = battleEntity.HP;
    }

    private void Update()
    {
        if (battleUI != null && battleEntity != null)
            battleUI.SetHPBar(CurrentHP, battleEntity.HP);
    }
    
    public int CalcDamageFrom(Battle attacker)
    {
        int atk = attacker.battleEntity.ATK;
        int dmg = atk - battleEntity.DEF;
        if (dmg <= 0) dmg = 1;
        return dmg;
    }

    public void ApplyDamage(int amount)
    {        
        CurrentHP = currentHP - amount;
    }

    public void ApplyGuardEffect() 
    {
        ShieldUp(1); 
        Recover(10); 
    }    

    public abstract void Attack(Battle other);

    public void TakeDamage(Battle attacker)
    {
        int dmg = CalcDamageFrom(attacker); 
        ApplyDamage(dmg);                 
    }

   
    public virtual void Recover(int amount)
    {
        CurrentHP = currentHP + amount; 
    }

    public virtual void ShieldUp(int amount)
    {
        battleEntity.DEF += amount;
        if (battleUI != null)
            battleUI.SetBattleUI(battleEntity);
    }

    public void Death()
    {
        Debug.Log($"{battleEntity.NAME} 사망! 현재 체력 : {currentHP}");
        
        if (battleManager != null)
            battleManager.GameOver(this);
    }
}
