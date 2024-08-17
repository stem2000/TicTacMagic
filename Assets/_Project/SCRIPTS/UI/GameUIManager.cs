using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] PauseMenu pauseMenu;
        [SerializeField] LoseMenu loseMenu;

        [HideInInspector] private UnityEvent OnMenuFold = new UnityEvent();
        [HideInInspector] private UnityEvent OnRestartActivated = new UnityEvent();
        [HideInInspector] private UnityEvent OnExitActivated = new UnityEvent();

        private PlayerInputActions inputActions;
        private IMenu currentMenu;

        private void Awake()
        {
            inputActions = new PlayerInputActions();

            inputActions.UI.UIEscape.performed += ctx => CloseMenuOnEscape();

            pauseMenu.ResumeButton.onClick.AddListener(ClosePauseMenu);
            DeactivateAllMenu();
        }

        public void LinkToController(GameController gameController)
        {
            gameController.OnPause.AddListener(OpenPauseMenu);
            gameController.OnLose.AddListener(OpenLoseMenu);

            loseMenu.RestartButton.onClick.AddListener(gameController.RestartGame);

            OnMenuFold.AddListener(gameController.UnpauseGame);
        }

        private void DeactivateAllMenu()
        {
            pauseMenu.gameObject.SetActive(false);
            loseMenu.gameObject.SetActive(false);
        }

        public void OpenPauseMenu()
        {
            pauseMenu.gameObject.SetActive(true);
            currentMenu = pauseMenu;
            inputActions.UI.Enable();
        }

        public void ClosePauseMenu()
        {
            pauseMenu.gameObject.SetActive(false);
            currentMenu = null;
            inputActions.UI.Disable();
            OnMenuFold?.Invoke();
        }

        public void OpenLoseMenu()
        {
            loseMenu.gameObject.SetActive(true);
            currentMenu = loseMenu;
        }

        private void CloseMenuOnEscape()
        {
            if (currentMenu is PauseMenu)
                ClosePauseMenu();
        }
    }
}
