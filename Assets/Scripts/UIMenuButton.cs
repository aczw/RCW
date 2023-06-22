using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMenuButton : MonoBehaviour, IPointerEnterHandler
{
    private void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(
            () => Audio.Instance.sfxSource.PlayOneShot(AudioClips.Instance.buttonClick)
        );
    }
        
    public void OnPointerEnter(PointerEventData eventData)
    {
        Audio.Instance.sfxSource.PlayOneShot(AudioClips.Instance.buttonHover);
    }
}