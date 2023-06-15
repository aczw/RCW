using UnityEngine;
using UnityEngine.UI;

namespace InGame
{
    public class UIPauseBtn : MonoBehaviour
    {
        [SerializeField] private Button pauseButton;

        private void Start()
        {
            Rcw.Instance.GameStart += () => pauseButton.interactable = true;
            Rcw.Instance.pauseManager.Paused += () => pauseButton.interactable = false;
            Rcw.Instance.pauseManager.Resumed += () => pauseButton.interactable = true;
        }
    }
}
