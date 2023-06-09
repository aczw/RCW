using System;
using System.Collections;
using UnityEngine;

public class MainCanvasBehavior : MonoBehaviour
{
    public RectTransform colorBg;
    public RectTransform barBg;
    public RectTransform livesBg;
    public RectTransform pauseBg;

    public IEnumerator StartSequence()
    {
        Debug.Log("color bg");
        StartCoroutine(TranslateColorBg(1f));

        yield return null;
    }

    private IEnumerator TranslateColorBg(float duration)
    {
        var elapsed = 0f;
        var initial = new Vector2(0, 1000);
        var final = new Vector2(0, 0);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            colorBg.anchoredPosition = Vector2.Lerp(initial, final, EaseOutCubic(elapsed / duration));
            
            yield return null;
        }
    }

    private static float EaseOutCubic(float num)
    {
        return (float) (1f - Math.Pow(1f - num, 3));
    }
}
