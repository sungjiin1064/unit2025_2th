using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICoinSpawnEvent : IEvent
{
    public Coin Coin;

    public ICoinSpawnEvent(Coin coin)
    {
        Coin = coin;
    }
}
