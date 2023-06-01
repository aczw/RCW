using System;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static GameSystem Instance { get; private set; }
    
    public RoundTimer Timer { get; private set; }
    private RoundProperty Property { get; set; }
    public bool Paused { get; private set; }

    public ColorData CurrText { get; private set; }
    public ColorData CurrColor { get; private set; }
    public int Score { get; private set; }
    public int Lives { get; private set; } = 3;
    public bool Reverse { get; private set; }

    private void WinRound()
    {
        Score += CalculateRoundScore();
        PrepareNextRound();
    }

    private void LoseRound()
    {
        var roundScore = CalculateRoundScore();
        if (Score - roundScore <= 0)
        {
            Score = 0;
        }
        else
        {
            Score -= roundScore;
        }
        
        Lives -= 1;
        PrepareNextRound();
    }

    private void PrepareNextRound()
    {
        if (Reverse)
        {
            Reverse = false;
        }
        
        (CurrText, CurrColor) = Property.ChooseColors();
        Reverse = RoundProperty.ChooseReverse();
        Timer.Reset();
    }

    private int CalculateRoundScore()
    {
        var current = Timer.CurrTime;
        var percentage = current / RoundTimer.RoundTime;
        var score = (int) Math.Round(100 * percentage);
        
        Debug.Log(score);

        return score;
    }

    public void TogglePause()
    {
        Paused = !Paused;
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
        Property = new RoundProperty();
    }

    private void Start()
    {
        // around 1 correct match for every 1.7 incorrect matches
        PrepareNextRound();
    }

    private void Update()
    {
        var match = CurrText.Equals(CurrColor);

        if (Timer.CurrTime <= 0.0f)
        {
            LoseRound();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if ((Reverse && match) || (!Reverse && !match))
            {
                LoseRound();
            }
            else
            {
                WinRound();
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if ((Reverse && match) || (!Reverse && !match))
            {
                WinRound();
            }
            else
            {
                LoseRound();
            }
        }
    }
}
