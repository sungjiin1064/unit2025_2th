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

    public void SetBattleUI(BattleEntity battleEntity)
    {
        BattleEntityText.SetText($"ATK : {battleEntity.ATK} / DEF : {battleEntity.DEF}");
    }
    public void SetHPBar(int current, int max)
    {
        HpBar.fillAmount = (float)current / max;
    }
}

public class Battle : MonoBehaviour
{
    public BattleEntity battleEntity;
    public BattleUI battleUI;

    public int CurrentHP;

    private void Start()
    {
        //battleEntity = new BattleEntity(playerHP, playerATK, playerDEF);
        Debug.Log($"ATK : {battleEntity.ATK}, DEF : {battleEntity.DEF}");
        battleUI.SetBattleUI(battleEntity);
        CurrentHP = battleEntity.HP;
    }
    private void Update()
    {
        battleUI.SetHPBar(CurrentHP, battleEntity.HP);
    }

}
