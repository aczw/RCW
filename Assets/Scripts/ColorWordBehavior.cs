using TMPro;
using UnityEngine;

public class ColorWordBehavior : MonoBehaviour
{
    public TMP_Text colorWordText;
    
    private void Start()
    {
        Rcw.Instance.ColorWordChanged += OnColorWordChanged;
        colorWordText.text = "";
        colorWordText.color = Color.white;
    }

    private void OnColorWordChanged()
    {
        colorWordText.text = Rcw.Instance.roundManager.RoundText.Name.ToLower();
        colorWordText.color = Rcw.Instance.roundManager.RoundColor.Color;
    }
}
