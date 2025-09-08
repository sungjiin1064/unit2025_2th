using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Buff
{
    public StatType type = StatType.UnDefined;
    public float value = 5.0f;
}
public class ObjectBuff : MonoBehaviour
{
    Entity_stats statsToMod;
    SpriteRenderer sr;

    [Header("น๖วม")]
    [SerializeField] Buff[] buffs;
    [SerializeField] private float buffTime = 2.0f;
    [SerializeField] private string buffName;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            statsToMod = collision.GetComponent<Entity_stats>();

            StartCoroutine(BuffCo());


        }
    }


    IEnumerator BuffCo()
    {
        sr.color = Color.clear;

        foreach (Buff buff in buffs)
        {
            statsToMod.GetStatbyType(buff.type).AddModifier(buff.value, buffName);

        }


        //statsToMod.StatData.Vitality.AddModifier(buddValue, buffName);
        Bus<IStatUpdateEvent>.Raise(new IStatUpdateEvent());

        yield return new WaitForSeconds(buffTime);

        foreach (Buff buff in buffs)
        {
            statsToMod.GetStatbyType(buff.type).RemoveModifier(buffName);
        }
        Bus<IStatUpdateEvent>.Raise(new IStatUpdateEvent());
        Destroy(gameObject);

    }

}
