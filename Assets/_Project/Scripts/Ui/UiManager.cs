using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TicTacMagic
{
    public class UiManager : MonoBehaviour, IGameStateListener
    {
        public event Action OnMenuOpened;

        public event Action OnMenuClosed;

        private IInputProvider inputProvider;

        [Inject]
        public void Construct(GameManager gameManager) {
            gameManager.OnGameStateChanged += ListenToGameState;
        }

        private void ListenToGameState(GameState gameState) {
        }
    }
}
