using UnityEngine;
using TMPro;

public class UIGameLoop : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text colorWordText;
    public TMP_Text timeText;
    public TMP_Text reverseText;

    private void Update()
    {
        scoreText.text = "Score: " + GameSystem.Instance.Score;
        livesText.text = GameSystem.Instance.Lives.ToString();
        colorWordText.text = GameSystem.Instance.CurrText.Name;
        colorWordText.color = GameSystem.Instance.CurrColor.Color;
        
        /*
        var time = GameSystem.Instance.Timer.CurrTime;
        timeText.text = time switch
        {
            > 2.0f => "3",
            > 1.0f => "2",
            _ => "1"
        };
        */
        timeText.text = GameSystem.Instance.Timer.CurrTime.ToString();

        reverseText.text = GameSystem.Instance.Reverse ? "REVERSED" : "";
    }
}
