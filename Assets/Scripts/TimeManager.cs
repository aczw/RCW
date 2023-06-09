using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public const float RoundTime = 3.0f;
    public float CurrTime { get; private set; } = RoundTime;

    private bool _paused = true;

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

    private void Start()
    {
        Rcw.Instance.GameStart += () => _paused = false;
        Rcw.Instance.GameLost += () => _paused = true;
    }

    private void Update()
    {
        if (!_paused)
        {
            CurrTime -= Time.deltaTime;
        }
    }
}
