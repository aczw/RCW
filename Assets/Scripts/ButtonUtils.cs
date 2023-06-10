using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUtils : MonoBehaviour
{
    public Animator animator;
    private static readonly int Exit = Animator.StringToHash("Exit");

    public void LoadSceneWrapper(string sceneName)
    {
        Time.timeScale = 1;
        StartCoroutine(LoadScene(sceneName));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        animator.SetTrigger(Exit);
        yield return new WaitForSeconds(0.5f);
        
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
