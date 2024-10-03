using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TicTacMagic
{
    public class UiManager : MonoBehaviour, IGameStateListener
    {
        public event Action OnUiOpened;

        public event Action OnUiClosed;

        [SerializeField]
        private UiPanel _pausePanel;

        private IInputProvider _inputProvider;


        [Inject]
        public void Construct(GameManager gameManager, IInputProvider inputProvider) {
            gameManager.OnGameStateChanged += ListenToGameState;
            _inputProvider = inputProvider;
        }

        private void ListenToGameState(GameState gameState) {
        }

        private void OpenPauseMenu() {

        }
    }
}
