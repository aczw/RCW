using UnityEngine;

public class AudioClips : MonoBehaviour
{
    public static AudioClips Instance { get; private set; }
    
    public AudioClip mainMenu;
    public AudioClip inGame;
    public AudioClip gameOver;
    
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
}
