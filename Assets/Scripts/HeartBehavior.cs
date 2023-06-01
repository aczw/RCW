using UnityEngine;

public class HeartBehavior : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.enabled = !GameSystem.Instance.Paused;
    }
}
