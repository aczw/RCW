using UnityEngine;

public class ReversedBehavior : MonoBehaviour
{
    private Animator _animator;
    private static readonly int Reversed = Animator.StringToHash("Reversed");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Rcw.Instance.RoundReversed += OnRoundReversed;
    }

    private void OnRoundReversed()
    {
        _animator.SetBool(Reversed, Rcw.Instance.roundManager.Reverse);
    }
}
