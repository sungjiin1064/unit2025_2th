using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEventUI : MonoBehaviour
{
    [Header("NPC UI")]
    public GameObject NPCPanel;    
    public Image NpcSprite;
    public TextMeshProUGUI NpcName;
    public TextMeshProUGUI NpcDialouge;

    [Header("GameOver UI")]
    public GameObject GameOverPanel;

    [Header("GameClear UI")]
    public GameObject GameClearPanel;

    private void Start()
    {
        NPCPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GameClearPanel.SetActive(false);
    }

    private void OnEnable()
    {
        Bus<ICollisionWithPlayerEvent>.OnEvent += HandleNPCUI;
        Bus<IGameOverEvent>.OnEvent += HandleGameOver;
        Bus<IGameClearEvent>.OnEvent += HandleGameClear;
    }
    private void OnDisable()
    {
        Bus<ICollisionWithPlayerEvent>.OnEvent -= HandleNPCUI;
        Bus<IGameOverEvent>.OnEvent -= HandleGameOver;
        Bus<IGameClearEvent>.OnEvent -= HandleGameClear;
    }

    private void HandleGameClear(IGameClearEvent evt)
    {
        GameClearPanel.SetActive(true);
    }

    private void HandleGameOver(IGameOverEvent evt)
    {
        Time.timeScale = 0f;  // 사용 후 원상태로 돌려줘야한다.(GameOverUI에 ReStart를 1로만들어준다)

        GameOverPanel.SetActive(true);
    }



    private void HandleNPCUI(ICollisionWithPlayerEvent evt)
    {
        NPCPanel.SetActive(true);

        NpcSprite.sprite = evt.NPC.nPCInfo.Sprite;
        NpcName.SetText(evt.NPC.nPCInfo.NpcName);
        NpcDialouge.SetText(evt.NPC.nPCInfo.NpcDialogue);

    }
}
