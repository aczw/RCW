using UnityEngine;
using TMPro;

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

public class ColorCreation : MonoBehaviour
{
    private TimerBehavior _timer;
    private ColorChoice _wordText;
    private ColorChoice _wordColor;
    
    private readonly ColorChoice[] _colors =
    {
        new("Red", new Color(0.953f, 0.545f, 0.659f)),
        new("Yellow", new Color(0.976f, 0.886f, 0.686f)),
        new("Green", new Color(0.651f, 0.89f, 0.631f)),
        new("Blue", new Color(0.537f, 0.706f, 0.98f)),
        new("Purple", new Color(0.796f, 0.651f, 0.969f))
    };
    
    public TMP_Text timeText;
    public TMP_Text colorText;
    
    private void ChooseColor()
    {
        _wordText = _colors[Random.Range(0, _colors.Length)];
        _wordColor = _colors[Random.Range(0, _colors.Length)];

        colorText.text = _wordText.Name;
        colorText.color = _wordColor.Color;
    }

    private void Awake()
    {
        _timer = GetComponent<TimerBehavior>();
    }

    private void Start()
    {
        ChooseColor();
    }

    private void Update()
    {
        var remaining = _timer.GetTime();

        if (remaining <= 0.0f)
        {
            _timer.Reset();
            ChooseColor();
        }
        
        timeText.text = remaining switch
        {
            > 2.0f => "3",
            > 1.0f => "2",
            _ => "1"
        };
    }
}
