using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public static bool Paused;
    public Button pauseButton;
    public Canvas pauseCanvas;

    public void TogglePause()
    {
        Paused = !Paused;
        Time.timeScale = Paused ? 0 : 1;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape) || Rcw.Instance.Lost)
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
