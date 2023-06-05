using System;
using UnityEngine;

public class Rcw : MonoBehaviour
{
    public static Rcw Instance { get; private set; }
    
    public event Action ScoreChanged;
    public event Action LifeLost;
    public event Action ColorWordChanged;
    public event Action RoundReversed;
    public event Action RoundWon;
    public event Action RoundLost;

    public TimeManager timeManager;
    public RoundManager roundManager;
    
    public int Score { get; private set; }
    public int Lives { get; private set; } = 3;
    
    private void WinRound()
    {
        RoundWon?.Invoke();
        
        Score += CalculateRoundScore();
        ScoreChanged?.Invoke();
        
        PrepareNextRound();
    }

    private void LoseRound()
    {
        RoundLost?.Invoke();
        
        var roundScore = 100 - CalculateRoundScore();
        if (Score - roundScore <= 0)
        {
            Score = 0;
        }
        else
        {
            Score -= roundScore;
        }
        ScoreChanged?.Invoke();
        
        Lives -= 1;
        LifeLost?.Invoke();
        
        PrepareNextRound();
    }

    private void PrepareNextRound()
    {
        var preReset = roundManager.Reverse;
        
        roundManager.ResetReverse();
        roundManager.ChooseReverse();

        if (roundManager.Reverse != preReset)
        {
            RoundReversed?.Invoke();
        }
        
        roundManager.ChooseColors();
        ColorWordChanged?.Invoke();
        
        timeManager.Reset();
    }

    private int CalculateRoundScore()
    {
        var current = timeManager.CurrTime;
        if (current < 0)
        {
            current = 0;
        }
        
        // make 100% a bit easier to get... 500ms reaction time is reasonable?
        var percentage = current / (TimeManager.RoundTime - 0.5f);
        var score = (int) Math.Round(100 * percentage);

        return Mathf.Clamp(score, 0, 100);
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        // around 1 correct match for every 1.7 incorrect matches
        PrepareNextRound();
    }

    private void Update()
    {
        if (timeManager.CurrTime <= 0.0f)
        {
            LoseRound();
        }

        if (PauseManager.Paused)
        {
            return;
        }
        
        var match = roundManager.RoundText.Equals(roundManager.RoundColor);
        var reversed = roundManager.Reverse;
        
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if ((reversed && match) || (!reversed && !match))
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
            if ((reversed && match) || (!reversed && !match))
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
