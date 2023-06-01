using UnityEngine;

public class RoundTimer : MonoBehaviour
{
    public const float RoundTime = 3.0f;
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

    private void Update()
    {
        if (!GameSystem.Instance.Paused)
        {
            CurrTime -= Time.deltaTime;
        }
    }
}
