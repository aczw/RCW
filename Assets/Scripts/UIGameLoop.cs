using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameLoop : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text colorWordText;
    public Slider timeSlider;

    private void Update()
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
        
        livesText.text = GameSystem.Instance.Lives.ToString();
        
        colorWordText.text = GameSystem.Instance.CurrText.Name.ToLower();
        colorWordText.color = GameSystem.Instance.CurrColor.Color;
        
        var time = GameSystem.Instance.Timer.CurrTime;
        timeSlider.value = time;
    }
}                           
