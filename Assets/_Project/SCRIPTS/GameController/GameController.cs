using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public class GameController : MonoBehaviour
    {
        public UnityEvent OnPauseGame;
        public UnityEvent OnUnpauseGame;

        private PlayerInputActions inputActions;
        private Player player;

        private void Awake()
        {
            inputActions = new PlayerInputActions();

            inputActions.Enable();
            inputActions.Player.PauseUnpause.performed += ctx => PauseGame();
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            player.enabled = false;
            inputActions.Disable();
            OnPauseGame?.Invoke();
        }

        public void UnpauseGame()
        {
            Time.timeScale = 1;
            player.enabled = true;
            inputActions.Enable();
            OnUnpauseGame?.Invoke();
        }


    }
}
