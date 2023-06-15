using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class UIExitGameBtn : MonoBehaviour
    {
        [SerializeField] private Button exitButton;

        private void Start()
        {
            exitButton.onClick.AddListener(ButtonUtils.ExitGame);
        }
    }
}
