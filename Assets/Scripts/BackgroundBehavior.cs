using UnityEngine;
using UnityEngine.UI;

public class BackgroundBehavior : MonoBehaviour
{
    public RawImage stripes;
    public float speed = 0.15f;

    private void Update()
    {
        if (!GameSystem.Instance.Paused)
        {
            stripes.uvRect = new Rect(
                stripes.uvRect.position + new Vector2(speed, speed) * Time.deltaTime,
                stripes.uvRect.size
            );
        }
    }
}
