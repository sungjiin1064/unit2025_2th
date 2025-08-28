using BattleExample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Example
{
    public class Monster : MonoBehaviour
    {
        public MonsterInfo monsterInfo;

        private void Start()
        {
            MonsterConstructor();

        }

        [ContextMenu("몬스터 생성")]
        private void MonsterConstructor()
        {
            GameObject instance = new GameObject();
            instance.transform.localScale = Vector3.one * monsterInfo.Size;
            SpriteRenderer sr = instance.AddComponent<SpriteRenderer>();
            sr.sprite = monsterInfo.sprite;
            MonsterMove move = instance.AddComponent<MonsterMove>();
            move.moveSpeed = monsterInfo.moveSpeed;
            Rigidbody2D rigid2D = instance.AddComponent<Rigidbody2D>();
            rigid2D.gravityScale = 0;
            CapsuleCollider2D cc2d = instance.AddComponent<CapsuleCollider2D>();
            cc2d.offset = new Vector2(1, 0);
            cc2d.size = new Vector2(2.24f, 2.27f);

            instance.name = monsterInfo.monsterName;
        }
    }
}






