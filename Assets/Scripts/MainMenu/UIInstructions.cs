using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MainMenu
{
    public class UIInstructions : MonoBehaviour
    {
        [SerializeField] private RectTransform background;
        [SerializeField] private GameObject text;
        [SerializeField] private Image mask;
        [SerializeField] private RectTransform instructionsPanel;

        [SerializeField] private RectTransform logo;
        [SerializeField] private RectTransform playButton;
        [SerializeField] private RectTransform exitButton;
        [SerializeField] private RectTransform creditsButton;

        private Vector2 _bgPosA;
        private Vector2 _bgPosB;
        
        private Vector2 _bgSizeA;
        private Vector2 _bgSizeB;

        private bool _open;

        private void Start()
        { 
            _bgPosA = background.anchoredPosition;
            _bgPosB = new Vector2(0, _bgPosA.y);
            
            _bgSizeA = background.sizeDelta;
            _bgSizeB = new Vector2(714, _bgSizeA.y);
        }

        public void ToggleInstructionsWrapper()
        {
            StopAllCoroutines();
            _open = !_open;
            StartCoroutine(_open ? OpenInstructions() : CloseInstructions());
        }

        private IEnumerator OpenInstructions()
        {
            StartCoroutine(TranslateX(logo, logo.anchoredPosition.x, 2600, 0.3f, true));

            yield return new WaitForSeconds(0.15f);
            
            StartCoroutine(TranslateX(creditsButton, creditsButton.anchoredPosition.x, 2000, 0.2f, true));

            yield return new WaitForSeconds(0.15f);
            
            StartCoroutine(TranslateX(exitButton, exitButton.anchoredPosition.x, 2000, 0.2f, true));
            
            yield return new WaitForSeconds(0.1f);
            
            StartCoroutine(TranslateX(playButton, playButton.anchoredPosition.x, 2000, 0.2f, true));
            StartCoroutine(TranslateX(instructionsPanel, instructionsPanel.anchoredPosition.x, 0, 0.5f, false));
            
            yield return new WaitForSeconds(0.2f);
            
            StartCoroutine(Transform(0.5f, _bgPosA, _bgPosB, _bgSizeA, _bgSizeB));
        }

        private IEnumerator CloseInstructions()
        {
            StartCoroutine(TranslateX(instructionsPanel, instructionsPanel.anchoredPosition.x, -2600, 0.3f, true));
            StartCoroutine(Transform(0.5f, _bgPosB, _bgPosA, _bgSizeB, _bgSizeA));
            
            yield return new WaitForSeconds(0.15f);
            
            StartCoroutine(TranslateX(playButton, playButton.anchoredPosition.x, -400, 0.4f, false));

            yield return new WaitForSeconds(0.1f);
            
            StartCoroutine(TranslateX(logo, logo.anchoredPosition.x, 0, 0.5f, false));
            StartCoroutine(TranslateX(exitButton, exitButton.anchoredPosition.x, 400, 0.4f, false));
            
            yield return new WaitForSeconds(0.15f);
            
            StartCoroutine(TranslateX(creditsButton, creditsButton.anchoredPosition.x, 947, 0.2f, false));
        }

        private IEnumerator Transform(
            float duration, 
            Vector2 initPos, Vector2 finPos, Vector2 initSize, Vector2 finSize
        )
        {
            var elapsed = 0f;

            StartCoroutine(_open ? ToggleText(0.5f) : ToggleText(0.1f));

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;

                var ratio = Easings.EaseOutQuint(elapsed / duration);
                background.anchoredPosition = Vector2.Lerp(initPos, finPos, ratio);
                background.sizeDelta = Vector2.Lerp(initSize, finSize, ratio);

                yield return null;
            }
        }

        private IEnumerator ToggleText(float duration)
        {
            var elapsed = 0f;
            
            if (_open)
            {
                yield return new WaitForSeconds(0.2f);
                
                text.SetActive(true);
                
                while (elapsed < duration)
                {
                    elapsed += Time.deltaTime;

                    var ratio = Mathf.Lerp(1, 0, elapsed / duration);
                    mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, ratio);

                    yield return null;
                }
            }
            else
            {
                while (elapsed < duration)
                {
                    elapsed += Time.deltaTime;

                    var ratio = Mathf.Lerp(0, 1, elapsed / duration);
                    mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, ratio);

                    yield return null;
                }
                
                text.SetActive(false);
            }
        }
        
        private static IEnumerator TranslateX(RectTransform element, float initX, float finalX, float duration, bool easeIn)
        {
            var elapsed = 0f;
            var y = element.anchoredPosition.y;
        
            var initial = new Vector2(initX, y);
            var final = new Vector2(finalX, y);

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;

                var ratio = elapsed / duration;
                element.anchoredPosition = Vector2.Lerp(
                    initial, final, 
                    easeIn ? Easings.EaseInQuint(ratio) : Easings.EaseOutQuint(ratio)
                );

                yield return null;
            }
        }
    }
}
