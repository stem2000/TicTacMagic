using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameMenuManager gameMenuManager;
        [SerializeField] private MusicPlayer musicPlayer;

        private PlayerInputActions playerInputActions;
        private Player player;

        private bool gameOnPause = false;

        private void Awake()
        {
            playerInputActions = new PlayerInputActions();

            playerInputActions.Enable();
            playerInputActions.Player.PauseUnpause.performed += ctx => PauseSwitch();

            gameMenuManager.AddListenerToUIOnPauseSwitch(PauseSwitch);
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        private void PauseSwitch()
        {
            gameOnPause = !gameOnPause;

            if(gameOnPause)
                PauseGame();
            else
                UnpauseGame();
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
            musicPlayer.Pause();
            player.enabled = false;
            gameMenuManager.OpenPauseMenu();
        }

        private void UnpauseGame()
        {
            Time.timeScale = 1;
            musicPlayer.Play();
            player.enabled = true;
            gameMenuManager.ClosePauseMenu();
        }


    }
}
