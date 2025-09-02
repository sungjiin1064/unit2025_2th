using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Example;

public class MonsterSpawner : MonoBehaviour
{
    // 특정 시점, 특정 이벤트가 발생되고 나서 몬스터를 생성하고 싶다

    [Header("몬스터 생성 정보")]
    [SerializeField] Transform[] spawnPositions;
    [SerializeField] GameObject[] spawnMonsters;
    [SerializeField] MonsterInfo[] monsterInfos;
    [SerializeField] int spawnCount = 5;
    [SerializeField] float spawnIntervalTime = 0.75f;
    private Coroutine spawnCoroutine;
    private Monster monster = new Monster();

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Spawn();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            monster = ConstructMonster();
            monster.MonsterConstructor();
        }
    }

    // monster의 데이터를 생성해주는 함수
    public Monster ConstructMonster()
    {
        Monster newMonster = new Monster();
        int rd = UnityEngine.Random.Range(0,monsterInfos.Length);
        newMonster.monsterInfo = monsterInfos[rd];
        return newMonster;
    }

    public void Spawn()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(SpawnCoroutine());
        }

        spawnCoroutine = StartCoroutine(SpawnCoroutine());
        //StartCoroutine(SpawnCoroutine()); // 사용방식을 1가지로 통일해서 써라.
        //StartCoroutine("SpawnCoroutine"); // string 매서드 이름을 가져올 때 문제점 : 철자,대소문자 틀리면 어디서 문제인지 버그찾기가 어렵다.
        //StartCoroutine(nameof(SpawnCoroutine)); // string 으로 할거면 이방식으로

    }

    private IEnumerator SpawnCoroutine()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, spawnPositions.Length);
            int randomMonsterIndex = UnityEngine.Random.Range(0, spawnMonsters.Length);

            Instantiate(spawnMonsters[randomMonsterIndex], spawnPositions[randomIndex]);

            yield return new WaitForSeconds(spawnIntervalTime);

        }
    }
}
