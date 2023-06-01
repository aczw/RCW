using TMPro;
using UnityEngine;

public class ColorWordBehavior : MonoBehaviour
{
    public TMP_Text colorWordText;
    
    private void Start()
    {
        GameSystem.Instance.ColorWordChanged += OnColorWordChanged;
        colorWordText.text = "";
        colorWordText.color = Color.white;
    }

    private void OnColorWordChanged()
    {
        colorWordText.text = GameSystem.Instance.roundManager.RoundText.Name.ToLower();
        colorWordText.color = GameSystem.Instance.roundManager.RoundColor.Color;
    }
}
