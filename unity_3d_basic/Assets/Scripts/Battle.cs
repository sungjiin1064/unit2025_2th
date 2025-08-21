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

public abstract class Battle : MonoBehaviour // 추상 클래스. 인스턴스 할 수 없다(오브젝트의 컴포넌트로 사용 할 수 없다).
{
    public BattleEntity battleEntity;
    public BattleUI battleUI;
    public BattleManager battleManager;
        
    public int CurrentHP {
        get {
            if(currentHP <= 0)
            {
                currentHP = 0;
                Death();
            }
            else
            {

            }
            return currentHP;
        }
        private set {
            if(value > battleEntity.HP) value = battleEntity.HP;
            currentHP = value;
        } 
    } // Battle 클래스에서 변경할 수 있다.
        
    private int currentHP;

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
        //Debug.Log($"최종데미지 : {FinalDamage}, 공격자의 공격력 : {other.battleEntity.ATK}, 방어력 : {battleEntity.DEF}");
    }
    public void Death()
    {
        Debug.Log($"사망했습니다. 현제 체력 : {currentHP}");
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
    
}
