using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Stat
{
    [SerializeField] private float baseValue;
    [SerializeField] private List<StatModifier> modifiers;

    public float GetValue()
    {
        return GetFianlValue();
    }

    public void AddModifier(float value, string source)
    {
        StatModifier modToAdd = new StatModifier(value, source);
        modifiers.Add(modToAdd);
    }

    public void RemoveModifier(string source)
    {
        modifiers.RemoveAll(mod => mod.source == source);
    }

    private float GetFianlValue()
    {
        float finalValue = baseValue;

        foreach(var mod in modifiers)
        {
            finalValue += mod.value;
        }

        return finalValue;
    }

}

[System.Serializable]
public class StatModifier
{
    public float value;
    public string source;

    public StatModifier(float value, string source)
    {
        this.value = value;
        this.source = source;
    }
}
