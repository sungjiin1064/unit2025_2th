using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearUI : MonoBehaviour
{    
    [SerializeField] Button QuitButton;

    public void OnEnable()
    {        
        QuitButton.onClick.AddListener(Quit);
    }

    public void OnDisable()
    {        
        QuitButton.onClick.RemoveAllListeners();
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif

        Application.Quit();

    }
      
}
