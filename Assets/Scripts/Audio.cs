using System.Collections;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio Instance { get; private set; }

    public AudioSource musicSource;
    public AudioSource sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator ChangeMusicVolume(float volume, float duration)
    {
        var initVol = musicSource.volume;
        var finalVol = Mathf.Clamp(volume, 0f, 1f);
        var elapsed = 0f;

        while (elapsed < duration)
        {
            // necessary because game may be paused
            elapsed += Time.unscaledDeltaTime;
            musicSource.volume = Mathf.Lerp(initVol, finalVol, elapsed / duration);

            yield return null;
        }
    }
}
