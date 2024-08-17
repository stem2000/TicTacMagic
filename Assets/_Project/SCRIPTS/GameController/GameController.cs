using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace TicTacMagic
{
    public class GameController : MonoBehaviour
    {
        public UnityEvent OnPause;
        public UnityEvent OnUnpause;
        public UnityEvent OnStopGame;
        public UnityEvent OnRunGame;
        public UnityEvent OnPlayerWin;
        public UnityEvent OnLose;

        private PlayerInputActions inputActions;
        private Player player;

        private void Awake()
        {
            inputActions = new PlayerInputActions();

            inputActions.Player.OnEscape.Enable();
            inputActions.Player.OnEscape.performed += ctx => PauseGame();
        }

        public void PauseGame()
        {
            StopGame();
            OnPause?.Invoke();
        }

        public void UnpauseGame()
        {
            RunGame();
            OnUnpause?.Invoke();
        }

        public void HandlePlayerWin()
        {
            OnPlayerWin?.Invoke();
        }

        public void HandlePlayerLose()
        {
            StopGame();
            OnLose?.Invoke();
        }

        public void RestartGame()
        {
            var scene = SceneManager.GetActiveScene();

            SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
            RunGame();
        }

        public void ExitGame()
        {
            
        }

        private void StopGame()
        {
            Time.timeScale = 0;
            inputActions.Player.OnEscape.Disable();
            OnStopGame?.Invoke();
        }

        private void RunGame()
        {
            Time.timeScale = 1;
            inputActions.Player.OnEscape.Enable();
            OnRunGame?.Invoke();
        }

    }
}
