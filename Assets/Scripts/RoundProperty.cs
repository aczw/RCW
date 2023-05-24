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
        new("Red", new Color(0.953f, 0.545f, 0.659f)),
        new("Yellow", new Color(0.976f, 0.886f, 0.686f)),
        new("Green", new Color(0.651f, 0.89f, 0.631f)),
        new("Blue", new Color(0.537f, 0.706f, 0.98f)),
        new("Purple", new Color(0.796f, 0.651f, 0.969f))
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

    public bool ChooseReverse()
    {
        // 0 or 1... 20% chance of reversal
        return Random.Range(0, 10) <= 1;
    }
}
