using UnityEngine;

public class ReversedBehavior : MonoBehaviour
{
    private Animator _animator;
    private static readonly int Reversed = Animator.StringToHash("Reversed");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(Reversed, GameSystem.Instance.Reverse);
    }
}
