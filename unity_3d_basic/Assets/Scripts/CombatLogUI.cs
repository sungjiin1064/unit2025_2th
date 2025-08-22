using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CombatLogUI : MonoBehaviour
{
    public static CombatLogUI I { get; private set; }

    [Header("References")]
    public TMP_Text logText;      // LogText 연결
    public ScrollRect scrollRect; // CombatLog 연결

    [Header("Options")]
    [SerializeField] private int maxLines = 100;
    [SerializeField] private bool showTimestamp = true;

    private readonly StringBuilder sb = new StringBuilder();
    private int lineCount = 0;

    private void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
    }

    public void Log(string message)
    {
        var line = showTimestamp ? $"{DateTime.Now:HH:mm:ss}  {message}" : message;
        AppendLine(line);
    }

    private void AppendLine(string line)
    {
        sb.AppendLine(line);
        lineCount++;

        if (lineCount > maxLines) TrimToMaxLines();

        if (logText) logText.text = sb.ToString();

        // 자동으로 맨 아래로 스크롤
        if (scrollRect)
        {
            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;
        }
    }

    private void TrimToMaxLines()
    {
        var all = sb.ToString().Split('\n');
        int start = Mathf.Max(0, all.Length - maxLines - 1);
        sb.Clear();
        for (int i = start; i < all.Length; i++)
        {
            if (all[i].Length > 0) sb.AppendLine(all[i]);
        }
        lineCount = Mathf.Min(maxLines, all.Length);
    }
}
