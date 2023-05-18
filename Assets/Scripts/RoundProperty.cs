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

    public RoundProperty()
    {
        _prevText = new ColorData();
        _prevColor = new ColorData();
    }
    
    private static readonly ColorData[] ColorList =
    {
        new("Red", new Color(0.953f, 0.545f, 0.659f)),
        new("Yellow", new Color(0.976f, 0.886f, 0.686f)),
        new("Green", new Color(0.651f, 0.89f, 0.631f)),
        new("Blue", new Color(0.537f, 0.706f, 0.98f)),
        new("Purple", new Color(0.796f, 0.651f, 0.969f))
    };
    
    public (ColorData, ColorData) ChooseColors()
    {
        var text = ColorList[Random.Range(0, ColorList.Length)];
        var color = ColorList[Random.Range(0, ColorList.Length)];

        while (_prevText.Equals(text) && _prevColor.Equals(color))
        {
            text = ColorList[Random.Range(0, ColorList.Length)];
            color = ColorList[Random.Range(0, ColorList.Length)];
        }

        _prevText = text;
        _prevColor = color;

        return (text, color);
    }

    public bool ChooseReverse()
    {
        var choice = Random.Range(0, 9) + 1;

        return false;
    }
}
