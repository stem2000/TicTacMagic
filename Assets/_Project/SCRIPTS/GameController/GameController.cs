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
        public UnityEvent OnPlayerWinGirl;
        public UnityEvent OnPlayerWin;
        public UnityEvent OnLose;

        private PlayerInputActions inputActions;
        private GemCounter gemCounter;

        private void Awake()
        {
            inputActions = new PlayerInputActions();

            inputActions.Player.OnEscape.Enable();
            inputActions.Player.OnEscape.performed += ctx => PauseGame();
        }

        public void SetGemCounter(GemCounter gemCounter)
        {
            this.gemCounter = gemCounter;
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
            StopGame();
            if (gemCounter.DoesPlayerGetGirl())
            {
                OnPlayerWinGirl?.Invoke();
                return;
            }

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

        public void RunNextLevel()
        {
            var nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
                nextSceneIndex = 0;

            SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
        }

        public void ExitGame()
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
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
