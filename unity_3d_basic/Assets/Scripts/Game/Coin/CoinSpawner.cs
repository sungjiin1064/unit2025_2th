using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    public int SpawnCount;
    public void OnEnable()
    {
        Bus<IGetCoinEvent>.OnEvent += HandleGetCoin;
    }
    public void OnDisable()
    {
        Bus<IGetCoinEvent>.OnEvent -= HandleGetCoin;
    }

    private void HandleGetCoin(IGetCoinEvent evt)
    {

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
