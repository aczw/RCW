using UnityEngine;

namespace InGame
{
    public class UIReversed : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        private static readonly int Reversed = Animator.StringToHash("Reversed");

        private void Start()
        {
            Rcw.Instance.ReverseChanged += OnReverseChanged;
        }

        private void OnReverseChanged()
        {
            animator.SetBool(Reversed, Rcw.Instance.roundManager.Reverse);
        }
    }
}
