using UnityEngine;

public class TimerBehavior : MonoBehaviour
{
    private const float WaitTime = 3.0f;
    private float _time = WaitTime;

    public void Reset()
    {
        // adding the time is more accurate over time than resetting it
        _time += WaitTime;
    }

    public float GetTime()
    {
        return _time;
    }

    private void Update()
    {
        _time -= Time.deltaTime;
    }
}
