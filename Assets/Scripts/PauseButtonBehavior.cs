using UnityEngine;
using UnityEngine.UI;

public class PauseButtonBehavior : MonoBehaviour
{
    public Button pauseButton;

    private void Start()
    {
        Rcw.Instance.GameStart += () => pauseButton.interactable = true;
    }
}
