using System;
using UnityEngine;
using Zenject;

namespace TicTacMagic {
    public class GameManager : MonoBehaviour
    {
        public event Action<GameState> OnGameStateChanged;

        private GameState _gameState;


        [Inject]
        public void Construct(PlayerSpawner playerSpawner, UiManager uiManager) {
            playerSpawner.OnPlayerSpawned += SubscribeToPlayer;
        }

        private void SubscribeToPlayer(Player player) {
            player.OnDeath += ChangeStateToEnded;
        }

        private void SubscribeToUi(UiManager uiManager) {
            uiManager.OnMenuOpened += ChangeStateToActive;
            uiManager.OnMenuClosed += ChangeStateToPause;
        }

        private void ChangeStateToEnded() {
            _gameState = GameState.Ended;

            OnGameStateChanged?.Invoke(_gameState);
        }

        private void ChangeStateToPause() {
            _gameState = GameState.Paused;
            Time.timeScale = 0;
            OnGameStateChanged?.Invoke(_gameState);
        }

        private void ChangeStateToActive() {
            _gameState = GameState.Active;
            Time.timeScale = 1;
            OnGameStateChanged?.Invoke(_gameState);
        }


    }
}
