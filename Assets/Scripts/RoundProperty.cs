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

public class RoundProperty
{
    private ColorData _prevText;
    private ColorData _prevColor;
    private int _untilGuarantee;

    public RoundProperty()
    {
        _prevText = RandomColor();
        _prevColor = RandomColor();
        _untilGuarantee = 3;
    }
    
    private static readonly ColorData[] ColorList =
    {
        new("Red", new Color(0.824f, 0.059f, 0.224f)),
        new("Yellow", new Color(0.875f, 0.557f, 0.114f)),
        new("Green", new Color(0.251f, 0.627f, 0.169f)),
        new("Blue", new Color(0.118f, 0.4f, 0.961f)),
        new("Purple", new Color(0.533f, 0.224f, 0.937f))
    };

    private static ColorData RandomColor()
    {
        return ColorList[Random.Range(0, ColorList.Length)];
    }
    
    public (ColorData, ColorData) ChooseColors()
    {
        var text = RandomColor();
        var color = RandomColor();
        
        if (!text.Equals(color))
        {
            _untilGuarantee -= 1;
        }
        
        if (_untilGuarantee == 0)
        {
            var match = RandomColor();
            text = match;
            color = match;

            _untilGuarantee = Random.Range(2, 8);
        }
        else
        {
            while (_prevText.Equals(text) && _prevColor.Equals(color))
            {
                text = RandomColor();
                color = RandomColor();
            }
        }
        
        _prevText = text;
        _prevColor = color;

        return (text, color);
    }

    public static bool ChooseReverse()
    {
        // 10% chance of reversal
        return Random.Range(0, 10) == 0;
    }
}
