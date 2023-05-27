using System;
using UnityEngine;

public class RoundTimer : MonoBehaviour
{
    private const float RoundTime = 3.0f;
    private bool _paused;
    public float CurrTime { get; private set; } = RoundTime;

    public void Reset()
    {
        // adding round time is more accurate over time than resetting it
        if (CurrTime + RoundTime > RoundTime)
        {
            CurrTime = RoundTime;
        }
        else
        {
            CurrTime += RoundTime;
        }
    }

    public void TogglePause()
    {
        _paused = !_paused;
    }

    private void Update()
    {
        if (!_paused)
        {
            CurrTime -= Time.deltaTime;
        }
    }
}
