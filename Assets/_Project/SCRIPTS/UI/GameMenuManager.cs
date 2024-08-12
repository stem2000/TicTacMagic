using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public class GameMenuManager : MonoBehaviour
    {
        [SerializeField] PauseMenu pauseMenu;

        [HideInInspector] public UnityEvent OnMenuClosed = new UnityEvent();
        [HideInInspector] public UnityEvent OnEscape = new UnityEvent();

        private void Awake()
        {
            pauseMenu.resumeButton.onClick.AddListener(ClosePauseMenu);
            pauseMenu.gameObject.SetActive(false);
        }

        public void OpenPauseMenu()
        {
            pauseMenu.gameObject.SetActive(true);
        }

        public void ClosePauseMenu()
        {
            pauseMenu.gameObject.SetActive(false);
            OnMenuClosed?.Invoke();
        }
    }
}
