using UnityEngine;
using UnityEngine.UI;

public class MainMenuBgBehavior : MonoBehaviour
{
    public RawImage stripes;
    public float speed = 0.05f;

    private void Update()
    {
        var size = new Vector2(
            Mathf.Lerp(-40, 40, Mathf.PingPong(Time.time * speed, 1)),
            stripes.uvRect.size.y
        );

        stripes.uvRect = new Rect(stripes.uvRect.position, size);
    }
}
