using UnityEngine;

namespace InGame
{
    public class UIStoplight : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        private static readonly int Time = Animator.StringToHash("Time");

        private void Update()
        {
            animator.SetFloat(Time, Rcw.Instance.timeManager.CurrTime);
        }
    }
}
