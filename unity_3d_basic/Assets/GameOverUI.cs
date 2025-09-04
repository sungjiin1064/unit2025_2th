using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] Button ReStartButton;
    [SerializeField] Button QuitButton;

    public void OnEnable()
    {
        ReStartButton.onClick.AddListener(ReStart);
        QuitButton.onClick.AddListener(Quit);
    }

    public void OnDisable()
    {
        ReStartButton.onClick.RemoveAllListeners();
        QuitButton.onClick.RemoveAllListeners();
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif

        Application.Quit();
        
    }

    public void ReStart()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }

}
