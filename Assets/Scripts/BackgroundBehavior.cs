using UnityEngine;
using UnityEngine.UI;

public class BackgroundBehavior : MonoBehaviour
{
    public RawImage stripes;
    public float speed = 0.15f;

    private float _uvRectSizeX;

    private void Start()
    {
        GameSystem.Instance.RoundReversed += OnRoundReversed;
        
        _uvRectSizeX = stripes.uvRect.size.x;
    }

    private void OnRoundReversed()
    {
        _uvRectSizeX *= -1;
    }

    private void Update()
    {
        stripes.uvRect = new Rect(
            stripes.uvRect.position + new Vector2(speed, speed) * Time.deltaTime,
            new Vector2(_uvRectSizeX, stripes.uvRect.size.y)
        );
    }
}
