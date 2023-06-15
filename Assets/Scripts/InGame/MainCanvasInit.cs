using System;
using System.Collections;
using UnityEngine;

namespace InGame
{
    public class MainCanvasInit : MonoBehaviour
    {
        [SerializeField] private RectTransform colorBg;
        [SerializeField] private RectTransform barBg;
        [SerializeField] private RectTransform livesBg;
        [SerializeField] private RectTransform pauseBg;

        [SerializeField] private RectTransform readyText;
        [SerializeField] private RectTransform goText;

        private void Start()
        {
            Rcw.Instance.GameInit += () => StartCoroutine(InitSequence());
        }
        
        private IEnumerator InitSequence()
        {
            yield return new WaitForSeconds(0.1f);
        
            StartCoroutine(TranslateY(colorBg, 1000, 0, 0.8f));
            StartCoroutine(TranslateY(barBg, -300, 300, 0.8f));
            
            yield return new WaitForSeconds(0.4f);

            StartCoroutine(TranslateY(readyText, 600, 0, 0.3f));
            StartCoroutine(TranslateY(livesBg, 400, -75, 0.8f));
            StartCoroutine(TranslateY(pauseBg, 300, -75, 0.8f));
            
            yield return new WaitForSeconds(1f);
        
            StartCoroutine(TranslateY(readyText, 0, -600, 0.3f));
            StartCoroutine(TranslateY(goText, 600, 0, 0.3f));

            yield return new WaitForSeconds(1f);
        
            StartCoroutine(TranslateY(goText, 0, -600, 0.3f));
        }

        private static IEnumerator TranslateY(RectTransform element, float initY, float finalY, float duration)
        {
            var elapsed = 0f;
            var x = element.anchoredPosition.x;
        
            var initial = new Vector2(x, initY);
            var final = new Vector2(x, finalY);

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                element.anchoredPosition = Vector2.Lerp(initial, final, EaseOutQuint(elapsed / duration));
            
                yield return null;
            }
        }

        private static float EaseOutQuint(float num)
        {
            return (float) (1 - Math.Pow(1 - num, 5));
        }
    }
}
