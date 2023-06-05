using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundBehavior : MonoBehaviour
{
    public Image background;
    public RawImage stripes;
    public float speed = 0.15f;

    private void OnRoundReversed()
    {
        stripes.uvRect = new Rect(
            stripes.uvRect.position,
            new Vector2(stripes.uvRect.size.x * -1, stripes.uvRect.size.y)
        );
    }

    private void OnRoundEnd()
    {
        StopAllCoroutines();
        StartCoroutine(PulseBackground(Rcw.Instance.roundManager.RoundText.Color, 1f));
        StartCoroutine(PulseStripes(Rcw.Instance.roundManager.RoundColor.Color, 1f));
    }

    private IEnumerator PulseBackground(Color pulseColor, float duration)
    {
        var elapsed = 0f;
        var finalColor = Color.white;
        
        background.color = pulseColor;
        
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            background.color = Color.Lerp(pulseColor, finalColor, elapsed / duration);
            
            yield return null;
        }
    }

    private IEnumerator PulseStripes(Color pulseColor, float duration)
    {
        var elapsed = 0f;
        var finalColor = new Color(0.8f, 0.8f, 0.8f);
        
        stripes.color = pulseColor;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            stripes.color = Color.Lerp(pulseColor, finalColor, elapsed / duration);

            yield return null;
        }
    }

    private void Start()
    {
        Rcw.Instance.RoundReversed += OnRoundReversed;
        Rcw.Instance.RoundWon += OnRoundEnd;
        Rcw.Instance.RoundLost += OnRoundEnd;
    }

    private void Update()
    {
        stripes.uvRect = new Rect(
            stripes.uvRect.position + new Vector2(speed, speed) * Time.deltaTime,
            stripes.uvRect.size
        );
    }
}
