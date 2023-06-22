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
            var lives = Rcw.Instance.Lives;

            if (lives == 1 && !Audio.Instance.sfxSource.loop)
            {
                Audio.Instance.sfxSource.loop = true;
                Audio.Instance.sfxSource.clip = AudioClips.Instance.lowLife;
                Audio.Instance.sfxSource.Play();
            }
            
            livesTextAnimator.SetTrigger(LostRound);
            heartAnimator.SetInteger(Lives, Rcw.Instance.Lives);
        
            livesText.text = lives.ToString();
        }
    }
}
