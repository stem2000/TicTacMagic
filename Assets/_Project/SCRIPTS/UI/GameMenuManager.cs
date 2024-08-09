using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public class GameMenuManager : MonoBehaviour
    {
        [SerializeField] PauseMenu pauseMenu;

        private UnityEvent OnPauseSwitch = new UnityEvent();

        private void Awake()
        {
           InitializePauseMenu();
        }

        public void AddListenerToUIOnPauseSwitch(UnityAction action)
        {
            OnPauseSwitch.AddListener(action);
        }

        public void RemoveListenerFromUIOnPauseSwitch(UnityAction action)
        {
            OnPauseSwitch.RemoveListener(action);
        }

        private void InvokeOnPauseSwitch()
        {
            OnPauseSwitch?.Invoke();
        }

        private void InitializePauseMenu()
        {
            pauseMenu.AddListenerToResumeButtonOnClick(InvokeOnPauseSwitch);
            pauseMenu.gameObject.SetActive(false);
        }

        public void OpenPauseMenu()
        {
            pauseMenu.gameObject.SetActive(true);
        }

        public void ClosePauseMenu()
        {
            pauseMenu.gameObject.SetActive(false);
        }
    }
}
