using UnityEngine;

public class HeartBehavior : MonoBehaviour
{
    private Animator _animator;
    private static readonly int Lives = Animator.StringToHash("Lives");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.enabled = !GameSystem.Instance.Paused;
        _animator.SetInteger(Lives, GameSystem.Instance.Lives);
    }
}
