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

    public void ChangeMusicClip(AudioClip clip)
    {
        musicSource.clip = clip;
    }

    public void PlayMusic()
    {
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void ResumeMusic()
    {
        musicSource.UnPause();
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
