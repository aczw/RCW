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
        
        switch (sceneName)
        {
            case "GameLoop":
                Audio.Instance.musicSource.clip = AudioClips.Instance.inGame;
                break;
            
            case "MainMenu":
                Audio.Instance.musicSource.clip = AudioClips.Instance.mainMenu;
                break;
        }
        
        Time.timeScale = 1;
        
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
