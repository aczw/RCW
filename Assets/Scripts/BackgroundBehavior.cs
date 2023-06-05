using UnityEngine;
using UnityEngine.UI;

public class BackgroundBehavior : MonoBehaviour
{
    public RawImage stripes;
    public float speed = 0.15f;

    private void Start()
    {
        Rcw.Instance.RoundReversed += OnRoundReversed;
    }

    private void OnRoundReversed()
    {
        stripes.uvRect = new Rect(
            stripes.uvRect.position,
            new Vector2(stripes.uvRect.size.x * -1, stripes.uvRect.size.y)
        );
    }

    private void Update()
    {
        stripes.uvRect = new Rect(
            stripes.uvRect.position + new Vector2(speed, speed) * Time.deltaTime,
            stripes.uvRect.size
        );
    }
}
