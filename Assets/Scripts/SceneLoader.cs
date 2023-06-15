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
        Time.timeScale = 1;
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
}
