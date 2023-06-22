using System;
using UnityEngine;

public class PauseBehavior : MonoBehaviour
{
    public event Action Paused;
    public event Action Resumed;

    private bool _lost;
    private bool _started;
    private bool _paused;

    public void TogglePause()
    {
        _paused = !_paused;
        
        if (_paused)
        {
            Paused?.Invoke();
            Time.timeScale = 0;
            Audio.Instance.musicSource.Pause();
        }
        else
        {
            Resumed?.Invoke();
            Time.timeScale = 1;
            Audio.Instance.musicSource.UnPause();
        }
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
            
        TogglePause();
    }
}
