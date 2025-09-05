using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EntityStats", menuName = "Custom/Stat System/EntityStats")]
public class Entity_statsData : ScriptableObject, ICloneable
{
    public Stat maxHealth;
    public Stat Strength;
    public Stat Dexerity;
    public Stat intelligence;
    public Stat Vitality;

    public object Clone()
    {
        return Instantiate(this);
    }
}
