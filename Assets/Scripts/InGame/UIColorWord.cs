using TMPro;
using UnityEngine;

namespace InGame
{
    public class UIColorWord : MonoBehaviour
    {
        [SerializeField] private TMP_Text colorWordText;
        [SerializeField] private Animator animator;
    
        private static readonly int NewRoundCw = Animator.StringToHash("NewRoundCW");
        private static readonly int NewRoundCcw = Animator.StringToHash("NewRoundCCW");

        private void Start()
        {
            Rcw.Instance.ColorWordChanged += OnColorWordChanged;
        
            colorWordText.text = "";
            colorWordText.color = Color.white;
        }

        private void OnColorWordChanged()
        {
            var choice = Random.Range(0, 2);
            animator.SetTrigger(choice == 0 ? NewRoundCw : NewRoundCcw);

            colorWordText.text = Rcw.Instance.roundManager.RoundText.Name.ToLower();
            colorWordText.color = Rcw.Instance.roundManager.RoundColor.Color;
        }
    }
}
