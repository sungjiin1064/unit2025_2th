using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [field:SerializeField] public int Value { get; private set; } = 5;

    private void Start()
    {
        Bus<ICoinSpawnEvent>.Raise(new ICoinSpawnEvent(this));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Bus<IGetCoinEvent>.Raise(new IGetCoinEvent(this));  
            gameObject.SetActive(false);
            //Destroy(this.gameObject);  // this 생략가능
        }
    }
    
}
