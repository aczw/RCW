using UnityEngine;

public struct ColorChoice
{
    public ColorChoice(string name, Color color)
    {
        Name = name;
        Color = color;
    }

    public string Name { get; }
    public Color Color { get; }
}

public static class RoundColor
{
    private static readonly ColorChoice[] ColorList =
    {
        new("Red", new Color(0.953f, 0.545f, 0.659f)),
        new("Yellow", new Color(0.976f, 0.886f, 0.686f)),
        new("Green", new Color(0.651f, 0.89f, 0.631f)),
        new("Blue", new Color(0.537f, 0.706f, 0.98f)),
        new("Purple", new Color(0.796f, 0.651f, 0.969f))
    };
    
    public static (ColorChoice, ColorChoice) ChooseColors()
    {
        var text = ColorList[Random.Range(0, ColorList.Length)];
        var color = ColorList[Random.Range(0, ColorList.Length)];

        return (text, color);
    }
}
