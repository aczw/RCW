using System;
using System.Collections;
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
    public event Action GameStart;
    public event Action GameLost;

    public TimeManager timeManager;
    public RoundManager roundManager;
    public PauseManager pauseManager;
    public MainCanvasBehavior mainCanvas;
    
    public int Score { get; private set; }
    public int Lives { get; private set; } = 3;
    
    private bool _lost;
    private bool _started;
    
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
        if (Lives == 0)
        {
            GameLost?.Invoke();
            _lost = true;
        }
        else
        {
            LifeLost?.Invoke();
            PrepareNextRound();
        }
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

    private IEnumerator StartSequence()
    {
        StartCoroutine(mainCanvas.StartSequence());
        
        // animate "Ready?" scrolling down
        Debug.Log("ready");
        yield return new WaitForSeconds(2f);
        
        // animate "Go!" scrolling down
        Debug.Log("go");
        yield return new WaitForSeconds(2f);
        
        // finally, we start the game
        Debug.Log("start game");
        _started = true;
        PrepareNextRound();
        
        GameStart?.Invoke();
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
        StartCoroutine(StartSequence());
    }

    private void Update()
    {
        if (pauseManager.Paused || _lost || !_started)
        {
            return;
        }
        
        if (timeManager.CurrTime <= 0.0f)
        {
            LoseRound();
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
