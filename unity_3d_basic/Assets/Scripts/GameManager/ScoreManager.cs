using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public int Score;
    public int BestScore;
    public const string _BESTSCORE = "BestScore";

    public void SaveScore(int currentScore)
    {
        if(currentScore < BestScore) { return; }

        PlayerPrefs.SetInt(_BESTSCORE, currentScore);
    }
    public void LoadScore()
    {
        if (PlayerPrefs.HasKey(_BESTSCORE))
        {
            BestScore = PlayerPrefs.GetInt(_BESTSCORE);
        }
        else
        {
            BestScore = 0;
        }
    }
}
