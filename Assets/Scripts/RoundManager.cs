using UnityEngine;

public struct ColorData
{
    public ColorData(string name, Color color)
    {
        Name = name;
        Color = color;
    }

    public string Name { get; }
    public Color Color { get; }
}

public class RoundManager : MonoBehaviour
{
    public ColorData RoundText { get; private set; }
    public ColorData RoundColor { get; private set; }
    public bool Reverse { get; private set; }
    
    private ColorData _prevText;
    private ColorData _prevColor;
    private int _untilGuarantee = 3;
    
    private static readonly ColorData[] ColorList =
    {
        new("Red", new Color(0.824f, 0.059f, 0.224f)),
        new("Yellow", new Color(0.875f, 0.768f, 0.114f)),
        new("Green", new Color(0.251f, 0.627f, 0.169f)),
        new("Blue", new Color(0.118f, 0.4f, 0.961f)),
        new("Purple", new Color(0.533f, 0.224f, 0.937f))
    };

    private void Awake()
    {
        _prevText = RandomColor();
        _prevColor = RandomColor();
    }

    private static ColorData RandomColor()
    {
        return ColorList[Random.Range(0, ColorList.Length)];
    }
    
    // around 1 correct match for every 1.7 incorrect matches
    public void ChooseColors()
    {
        
        RoundText = RandomColor();
        RoundColor = RandomColor();
        
        if (!RoundText.Equals(RoundColor))
        {
            _untilGuarantee -= 1;
        }
        
        if (_untilGuarantee == 0)
        {
            RoundColor = RoundText;
            _untilGuarantee = Random.Range(2, 8);
        }
        else
        {
            while (_prevText.Equals(RoundText) && _prevColor.Equals(RoundColor))
            {
                RoundText = RandomColor();
                RoundColor = RandomColor();
            }
        }
        
        _prevText = RoundText;
        _prevColor = RoundColor;
    }

    public void ChooseReverse()
    {
        // 10% chance of reversal
        Reverse = Random.Range(0, 10) == 0;
    }

    public void ResetReverse()
    {
        Reverse = false;
    }
}
