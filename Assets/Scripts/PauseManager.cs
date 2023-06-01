using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool Paused;

    public void TogglePause()
    {
        Paused = !Paused;
        Time.timeScale = Paused ? 0 : 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
}
