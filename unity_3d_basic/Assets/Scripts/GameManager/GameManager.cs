using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    public void GameClear()
    {      
        if (IsGameClear())
        {
            Bus<IGameClearEvent>.Raise(new IGameClearEvent());
        }
    }
    public bool IsGameClear()
    {
        // 게임 클리어를 위한 조건이 필요하다면 해당 if문안에 작성
        //if()
        //{
        //    return true;
        //}
        return true;
    }   

    public void GameOver()
    {
        // 게임오버된걸 Bus<I~~~Event>.Raise(new ~~());
        Bus<IGameOverEvent>.Raise(new IGameOverEvent());
    }
}
