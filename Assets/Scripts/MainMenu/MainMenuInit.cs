using UnityEngine;

namespace MainMenu
{
    public class MainMenuInit : MonoBehaviour
    {
        private void Start()
        {
            Audio.Instance.ChangeMusicClip(AudioClips.Instance.mainMenu);
            StartCoroutine(Audio.Instance.ChangeMusicVolume(0.8f, 0.4f));
            Audio.Instance.PlayMusic();
        }
    }
}
