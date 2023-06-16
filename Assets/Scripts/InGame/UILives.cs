using TMPro;
using UnityEngine;

namespace InGame
{
    public class UILives : MonoBehaviour
    {
        [SerializeField] private Animator heartAnimator;
        [SerializeField] private Animator livesTextAnimator;
        [SerializeField] private TMP_Text livesText;
    
        private static readonly int LostRound = Animator.StringToHash("LostRound");
        private static readonly int Lives = Animator.StringToHash("Lives");

        private void Start()
        {
            Rcw.Instance.LifeLost += OnLifeLost;
        
            livesText.text = "3";
        }

        private void OnLifeLost()
        {
            livesTextAnimator.SetTrigger(LostRound);
            heartAnimator.SetInteger(Lives, Rcw.Instance.Lives);
        
            livesText.text = Rcw.Instance.Lives.ToString();
        }
    }
}