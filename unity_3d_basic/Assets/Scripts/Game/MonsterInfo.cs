using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
*/ 
namespace Example
{  
    [CreateAssetMenu(fileName = "Default Monster Name", menuName = "ScriptableObject/MonsterData", order = 100)]
    public class MonsterInfo : ScriptableObject
    {
        public float moveSpeed;
        public Sprite sprite;
        public float Size;
        public string monsterName;
        //public Collider2D collider2D;

    }
}
