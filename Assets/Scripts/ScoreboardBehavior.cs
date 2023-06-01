using UnityEngine;
using TMPro;

public class ScoreboardBehavior : MonoBehaviour
{
    public TMP_Text scoreText;
    public Animator animator;
    
    private static readonly int WonRound = Animator.StringToHash("WonRound");
    private static readonly int LostRound = Animator.StringToHash("LostRound");

    private void Start()
    {
        GameSystem.Instance.ScoreChanged += OnScoreChanged;
        GameSystem.Instance.RoundWon += OnRoundWon;
        GameSystem.Instance.RoundLost += OnRoundLost;
        
        scoreText.text = "000000";
    }

    private void OnRoundWon()
    {
        animator.SetTrigger(WonRound);
    }

    private void OnRoundLost()
    {
        animator.SetTrigger(LostRound);
    }

    private void OnScoreChanged()
    {
        var score = GameSystem.Instance.Score;
        scoreText.text = score switch
        {
            >= 100000 => score.ToString(),
            >= 10000 => "0" + score,
            >= 1000 => "00" + score,
            >= 100 => "000" + score,
            >= 10 => "0000" + score,
            >= 1 => "00000" + score,
            _ => "000000"
        };
    }
}
