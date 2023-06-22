using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InGame
{
    public class UIPauseBtn : MonoBehaviour, IPointerEnterHandler
    {
        [SerializeField] private Button pauseButton;

        private void Start()
        {
            Rcw.Instance.GameStart += () => pauseButton.interactable = true;
            
            Rcw.Instance.pauseManager.Paused += () =>
            {
                pauseButton.interactable = false;
                Audio.Instance.sfxSource.PlayOneShot(AudioClips.Instance.pauseOn);
            };
            
            Rcw.Instance.pauseManager.Resumed += () =>
            {
                pauseButton.interactable = true;
                Audio.Instance.sfxSource.PlayOneShot(AudioClips.Instance.pauseOff);
            };
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Audio.Instance.sfxSource.PlayOneShot(AudioClips.Instance.buttonHover);
        }
    }
}
