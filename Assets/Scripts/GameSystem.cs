using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static GameSystem Instance { get; private set; }
    
    public ColorChoice CurrText { get; private set; }
    public ColorChoice CurrColor { get; private set; }
    public int Score { get; private set; }
    public int Lives { get; private set; } = 3;
    public RoundTimer Timer { get; private set; }

    private void WinRound()
    {
        Score += 100;
        PrepareNextRound();
    }

    private void LoseRound()
    {
        Score -= 100;
        Lives -= 1;
        PrepareNextRound();
    }

    private void PrepareNextRound()
    {
        (CurrText, CurrColor) = RoundColor.ChooseColors();
        Timer.Reset();
    }

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        Timer = GetComponent<RoundTimer>();
    }

    private void Start()
    {
        (CurrText, CurrColor) = RoundColor.ChooseColors();
    }

    private void Update()
    {
        var match = CurrText.Equals(CurrColor);

        if (Timer.CurrTime <= 0.0f)
        {
            LoseRound();
        }
        
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (match)
            {
                WinRound();
            }
            else
            {
                LoseRound();
            }
        } else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (match)
            {
                LoseRound();
            }
            else
            {
                WinRound();
            }
        }
    }
}
