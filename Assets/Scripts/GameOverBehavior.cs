using UnityEngine;
using TMPro;

public class GameOverBehavior : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject gameOverCanvas;
    public GameObject pauseCanvas;
    
    public TMP_Text score;
    public TMP_Text colorWord;
    
    private void Start()
    {
        Rcw.Instance.GameLost += OnGameLost;
    }

    private void OnGameLost()
    {
        mainCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);

        score.text = Rcw.Instance.Score.ToString();
        colorWord.text = Rcw.Instance.roundManager.RoundText.Name.ToLower();
        colorWord.color = Rcw.Instance.roundManager.RoundColor.Color;
        
        Destroy(mainCanvas);
        Destroy(pauseCanvas);
    }
}
