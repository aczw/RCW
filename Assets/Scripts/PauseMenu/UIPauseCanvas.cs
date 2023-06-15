using UnityEngine;

namespace PauseMenu
{
    public class UIPauseCanvas : MonoBehaviour
    {
        [SerializeField] private Canvas pauseCanvas;
        
        private void Start()
        {
            Rcw.Instance.pauseManager.Paused += () => pauseCanvas.enabled = true;
            Rcw.Instance.pauseManager.Resumed += () => pauseCanvas.enabled = false;
        }
    }
}
