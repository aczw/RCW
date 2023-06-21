using UnityEngine;

namespace MainMenu
{
    public class MainMenuInit : MonoBehaviour
    {
        private void Start()
        {
            Audio.Instance.musicSource.clip = AudioClips.Instance.mainMenu;
            StartCoroutine(Audio.Instance.ChangeMusicVolume(0.8f, 0.4f));
            Audio.Instance.musicSource.Play();
        }
    }
}
