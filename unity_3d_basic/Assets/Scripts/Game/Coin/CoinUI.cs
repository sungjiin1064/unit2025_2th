using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;

    private int currentCoin;

    private void OnEnable()
    {
        Bus<IGetCoinEvent>.OnEvent += HandleGetCoin;
    }

    private void OnDisable()
    {
        Bus<IGetCoinEvent>.OnEvent -= HandleGetCoin;
    }
    private void Start()
    {
        currentCoin = 0;
        Bus<IGetCoinEvent>.Raise(new IGetCoinEvent()); 
    }
    private void HandleGetCoin(IGetCoinEvent evt)
    {
        if(evt.Coin == null)
        {
            Debug.LogWarning("Coin 정보가 없습니다.",this);

        }
        else
        {
            currentCoin += evt.Coin.Value;
        }
        coinText.SetText($"Current Coin : {currentCoin}");
    }
}
