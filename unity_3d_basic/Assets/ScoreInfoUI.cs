using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestscoreText;

    private int currentScore;  

    private void OnEnable()
    {
        Bus<IScoreUpdateEvent>.OnEvent += HandleScoreUpdate;        
    }
    private void OnDisable()
    {
        Bus<IScoreUpdateEvent>.OnEvent -= HandleScoreUpdate;
        
    }

    private void HandleScoreUpdate(IScoreUpdateEvent evt)
    {
        currentScore += evt.Score;
        scoreText.SetText($"         Score : {currentScore}");
        
    }

    public void SetScoreInfo()
    {
        currentScore = ScoreManager.Instance.Score;
        scoreText.SetText($"         Score :  {currentScore}");
        ScoreManager.Instance.LoadScore();
        bestscoreText.SetText($"  BestScore :  {ScoreManager.Instance.BestScore}");
    }
    private void Start()
    {
        SetScoreInfo();
    }
    public void SaveBestScore()
    {
        ScoreManager.Instance.SaveScore(currentScore);
    }

    private void Update()
    {
        //SetScoreInfo();

        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("현재 점수를 저장합니다.");
            Debug.Log(Application.persistentDataPath);
            SaveBestScore();
        }
        
    }
}
