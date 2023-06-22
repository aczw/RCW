using UnityEngine;

namespace InGame
{
    public class UIStoplight : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private int _prevTime = (int) Timer.RoundTime;
        
        private static readonly int Time = Animator.StringToHash("Time");

        private void Update()
        {
            var currTime = Rcw.Instance.timeManager.CurrTime;
            var floorTime = Mathf.FloorToInt(currTime);
            
            if (floorTime < _prevTime)
            {
                Audio.Instance.sfxSource.PlayOneShot(AudioClips.Instance.stoplight);
            }

            _prevTime = floorTime;
            
            animator.SetFloat(Time, currTime);
        }
    }
}
