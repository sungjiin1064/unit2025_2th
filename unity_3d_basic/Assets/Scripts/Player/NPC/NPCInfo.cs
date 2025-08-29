using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "None", menuName = "ScriptableObject/NPCData", order = 101)]
public class NPCInfo : ScriptableObject
{
    public int MinSpeed;
    public int MaxSpeed;
    public float PatrolRadius;
    public float stopDistance = 0.1f;
    public float patrolDistance = 5f;
    public Sprite Sprite;
    public string NpcName;
}
