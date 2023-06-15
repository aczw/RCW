using TMPro;
using UnityEngine;

namespace InGame
{
    public class UIGameOver : MonoBehaviour
    {
        [SerializeField] private GameObject mainCanvas;
        [SerializeField] private GameObject gameOverCanvas;
        [SerializeField] private GameObject pauseCanvas;
    
        [SerializeField] private TMP_Text score;
        [SerializeField] private TMP_Text colorWord;
    
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
}
