using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] PlayerSpawner playerSpawner;

        private void Start()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            IInputProvider inputProvider = new PlayerInputActionsWrapper();
            playerSpawner.SpawnPlayer(inputProvider);
        }
    }
}
