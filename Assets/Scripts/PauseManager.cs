using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public static bool paused;
    public Button pauseButton;
    public Canvas pauseCanvas;

    private bool _lost;

    public void TogglePause()
    {
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
    }

    private void Start()
    {
        Rcw.Instance.GameLost += () => _lost = true;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape) || _lost)
        {
            return;
        }
        
        if (paused)
        {
            pauseButton.interactable = true;
            pauseCanvas.enabled = false;
        }
        else
        {
            pauseButton.interactable = false;
            pauseCanvas.enabled = true;
        }
            
        TogglePause();
    }
}
