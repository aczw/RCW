using UnityEngine;
using UnityEngine.UI;

public class TimeSliderBehavior : MonoBehaviour
{
    public Slider timeSlider;

    private void Update()
    {
        timeSlider.value = Rcw.Instance.timeManager.CurrTime;
    }
}
