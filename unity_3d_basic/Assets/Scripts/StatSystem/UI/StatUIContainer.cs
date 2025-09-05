using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUIContainer : MonoBehaviour
{
    [SerializeField] Entity_stats playerStat;

    public StatUIElement[] stats;

    public void Start()
    {
        stats[0].SetUI(playerStat.StatData.Strength.GetValue());
        stats[1].SetUI(playerStat.StatData.Dexerity.GetValue());
        stats[2].SetUI(playerStat.StatData.intelligence.GetValue());
        stats[3].SetUI(playerStat.StatData.Vitality.GetValue());
    }
}
