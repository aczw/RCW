using UnityEngine;

public class AudioClips : MonoBehaviour
{
    public static AudioClips Instance { get; private set; }
    
    public AudioClip mainMenuMusic;
    public AudioClip inGameMusic;
    public AudioClip gameOverMusic;

    public AudioClip buttonClick;
    public AudioClip buttonHover;

    public AudioClip pauseOn;
    public AudioClip pauseOff;
    
    public AudioClip roundWon;
    public AudioClip roundLost;

    public AudioClip ready;
    public AudioClip go;

    public AudioClip stoplight;

    public AudioClip gameOver;

    public AudioClip lowLife;

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
