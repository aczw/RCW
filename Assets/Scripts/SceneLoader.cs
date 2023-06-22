using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator animator;
    
    private static readonly int Exit = Animator.StringToHash("Exit");

    public void LoadSceneWrapper(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        animator.SetTrigger(Exit);
        
        StartCoroutine(Audio.Instance.ChangeMusicVolume(0f, 0.4f));

        // realtime because game may be paused
        yield return new WaitForSecondsRealtime(0.5f);

        Audio.Instance.musicSource.clip = sceneName switch
        {
            "GameLoop" => AudioClips.Instance.inGameMusic,
            "MainMenu" => AudioClips.Instance.mainMenuMusic,
            _ => Audio.Instance.musicSource.clip
        };
        Audio.Instance.sfxSource.Stop();

        Time.timeScale = 1;
        
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
