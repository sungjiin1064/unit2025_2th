using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_stats : MonoBehaviour
{
    [SerializeField] private Entity_statsData statData;
    public Entity_statsData StatData { get; set; }

    public float GetMaxHealth()
    {
        float baseHP = statData.maxHealth.GetValue();
        float bonusHP = statData.Vitality.GetValue() * 5;

        return baseHP + bonusHP;
    }

    private void Awake()
    {
        StatData = (Entity_statsData)statData.Clone();
        
    }
    public Stat GetStatbyType(StatType type)
    {
        switch (type)
        {
            case StatType.Strength: return StatData.Strength;                
            case StatType.Dexerity: return StatData.Dexerity;              
            case StatType.Intelligence: return StatData.intelligence;           
            case StatType.Vitality: return StatData.Vitality;               
            case StatType.UnDefined:
                {
                    Debug.Log("지정된 statType이 존재하지 않습니다.");
                    return null;
                }
            default: return null;   
             
        }
    }
}