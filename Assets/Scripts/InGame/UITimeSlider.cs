using UnityEngine;
using UnityEngine.UI;

namespace InGame
{
    public class UITimeSlider : MonoBehaviour
    {
        [SerializeField] private Slider timeSlider;

        private void Update()
        {
            timeSlider.value = Rcw.Instance.timeManager.CurrTime;
        }
    }
}
