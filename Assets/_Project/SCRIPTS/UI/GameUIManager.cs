using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] PauseMenu pauseMenu;
        [SerializeField] LoseMenu loseMenu;
        [SerializeField] WinMenu winMenu;
        [SerializeField] WinMenu girlWinMenu;

        [HideInInspector] private UnityEvent OnMenuFold = new UnityEvent();

        private PlayerInputActions inputActions;
        private IMenu currentMenu;

        private void Awake()
        {
            inputActions = new PlayerInputActions();
            inputActions.UI.UIEscape.performed += ctx => CloseMenuOnEscape();

            pauseMenu.ResumeButton.onClick.AddListener(ClosePauseMenu);
            pauseMenu.RestartButton.onClick.AddListener(inputActions.UI.Disable);
            DeactivateAllMenu();
        }

        public void LinkToController(GameController gameController)
        {
            gameController.OnPause.AddListener(OpenPauseMenu);
            gameController.OnLose.AddListener(OpenLoseMenu);
            gameController.OnPlayerWin.AddListener(OpenWinMenu);
            gameController.OnPlayerWinGirl.AddListener(OpenGirlWinMenu);

            loseMenu.RestartButton.onClick.AddListener(gameController.RestartGame);
            pauseMenu.RestartButton.onClick.AddListener(gameController.RestartGame);

            winMenu.ContinueButton.onClick.AddListener(gameController.RunNextLevel);
            girlWinMenu.ContinueButton.onClick.AddListener(gameController.RunNextLevel);

            loseMenu.ExitButton.onClick.AddListener(gameController.ExitGame);
            winMenu.ExitButton.onClick.AddListener(gameController.ExitGame);
            girlWinMenu.ExitButton.onClick.AddListener(gameController.ExitGame);
            pauseMenu.ExitButton.onClick.AddListener(gameController.ExitGame);

            OnMenuFold.AddListener(gameController.UnpauseGame);
        }

        private void DeactivateAllMenu()
        {
            pauseMenu.gameObject.SetActive(false);
            loseMenu.gameObject.SetActive(false);
            winMenu.gameObject.SetActive(false);
            girlWinMenu.gameObject.SetActive(false);
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

        public void OpenWinMenu()
        {
            winMenu.gameObject.SetActive(true);
            currentMenu = winMenu;
        }

        public void OpenGirlWinMenu()
        {
            girlWinMenu.gameObject.SetActive(true);
            currentMenu = girlWinMenu;
        }

        private void CloseMenuOnEscape()
        {
            if (currentMenu.Equals(pauseMenu))
                ClosePauseMenu();
        }
    }
}
