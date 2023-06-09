using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public bool Paused { get; private set; }
    
    public Button pauseButton;
    public Canvas pauseCanvas;

    private bool _lost;
    private bool _started;

    public void TogglePause()
    {
        Paused = !Paused;
        Time.timeScale = Paused ? 0 : 1;
    }

    private void Start()
    {
        Rcw.Instance.GameStart += () => _started = true;
        Rcw.Instance.GameLost += () => _lost = true;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape) || _lost || !_started)
        {
            return;
        }
        
        if (Paused)
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
