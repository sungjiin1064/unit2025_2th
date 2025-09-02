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

    private void OnEnable()
    {
        Bus<ICollisionWithPlayerEvent>.OnEvent += HandleNPCUI;
    }
    private void OnDisable()
    {
        Bus<ICollisionWithPlayerEvent>.OnEvent -= HandleNPCUI;
    }

    private void Start()
    {
        NPCPanel.SetActive(false);
    }

    private void HandleNPCUI(ICollisionWithPlayerEvent evt)
    {
        NPCPanel.SetActive(true);

        NpcSprite.sprite = evt.NPC.nPCInfo.Sprite;
        NpcName.SetText(evt.NPC.nPCInfo.NpcName);
        NpcDialouge.SetText(evt.NPC.nPCInfo.NpcDialogue);

    }
}
