using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MainMenu
{
    public class UIPlayBtn : MonoBehaviour, IPointerEnterHandler
    {
        [SerializeField] private Button playButton;
    
        private void Start()
        {
            playButton.onClick.AddListener(() => Audio.Instance.sfxSource.PlayOneShot(AudioClips.Instance.buttonClick));
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Audio.Instance.sfxSource.PlayOneShot(AudioClips.Instance.buttonHover);
        }
    }
}
