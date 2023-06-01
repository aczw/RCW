using TMPro;
using UnityEngine;

public class LivesBehavior : MonoBehaviour
{
    public Animator animator;
    public TMP_Text livesText;
    
    private static readonly int Lives = Animator.StringToHash("Lives");

    private void Start()
    {
        GameSystem.Instance.LivesChanged += OnLivesChanged;
        livesText.text = "3";
    }

    private void OnLivesChanged()
    {
        animator.SetInteger(Lives, GameSystem.Instance.Lives);
        livesText.text = GameSystem.Instance.Lives.ToString();
    }
}
