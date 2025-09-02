using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    public int SpawnCount; // 한번에 생성할 동전의 개수
    public List<Coin> spawnedList = new();
    public int SpawnedCount; // 씬 에 생성된 코인 수

    public void OnEnable()
    {
        Bus<IGetCoinEvent>.OnEvent += HandleGetCoin;
        Bus<ICoinSpawnEvent>.OnEvent += HandleSpawnCoin;
    }
    public void OnDisable()
    {
        Bus<IGetCoinEvent>.OnEvent -= HandleGetCoin;
        Bus<ICoinSpawnEvent>.OnEvent -= HandleSpawnCoin;
    }

    private void HandleSpawnCoin(ICoinSpawnEvent evt)
    {
        spawnedList.Add(evt.Coin);
        SpawnedCount++;
    }

    private void HandleGetCoin(IGetCoinEvent evt)
    {
        spawnedList.Remove(evt.Coin);
        SpawnedCount--;

        if (SpawnCount > 2) { return; }       

        for (int i = 0; i < SpawnCount; i++)
        {
            Vector2 randomSpawnPos = UnityEngine.Random.insideUnitCircle * 5;
            Instantiate(CoinPrefab, transform.position + (Vector3)randomSpawnPos, Quaternion.identity);
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(Vector3.zero, 5);
    }
}
