using System;
using UnityEngine;

public class StoplightBehavior : MonoBehaviour
{
    private Animator _animator;
    private static readonly int Time = Animator.StringToHash("Time");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.enabled = !GameSystem.Instance.Paused;
        _animator.SetFloat(Time, GameSystem.Instance.Timer.CurrTime);
    }
}
