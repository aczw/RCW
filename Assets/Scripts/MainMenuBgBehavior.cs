using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBgBehavior : MonoBehaviour
{
    public Image background;
    public RawImage checkerboard;
    public float speed;

    private float _time;
    private int _x = -1;
    private int _y = 1;

    private void SwitchColor()
    {
        StopAllCoroutines();
        StartCoroutine(FadeColor(checkerboard.color, RoundManager.RandomColor().Color));
    }

    private IEnumerator FadeColor(Color init, Color final)
    {
        const float duration = 1f;
        var elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            var temp = Color.Lerp(init, final, elapsed / duration);
            background.color = temp * 0.85f;
            checkerboard.color = temp;

            yield return null;
        }

        background.color = final * 0.85f;
        checkerboard.color = final;
    }

    private void Start()
    {
        var chosen = RoundManager.RandomColor().Color;
        background.color = chosen * 0.85f;
        checkerboard.color = chosen;
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= 5f)
        {
            _time -= 5f;
            SwitchColor();

            var choice = Random.Range(0, 2);
            _x = choice == 0 ? 1 : -1;
            
            choice = Random.Range(0, 2);
            _y = choice == 0 ? 1 : -1;

            speed = Random.Range(0.1f, 0.8f);
        }
        
        var length = Mathf.Lerp(2, 10, Mathf.PingPong(Time.time * 0.05f, 1));
        checkerboard.uvRect = new Rect(
                checkerboard.uvRect.position + new Vector2(speed * _x, speed * _y) * Time.deltaTime,
                new Vector2(length, length)
        );
    }
}
