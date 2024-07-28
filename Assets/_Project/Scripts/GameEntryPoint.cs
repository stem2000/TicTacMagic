using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] PlayerSpawner playerSpawner;
        [SerializeField] LightningSpawner lightningSpawner;
        [SerializeField] HealthBar healthBar;

        private IPlayer player;

        private void Awake()
        {
            SpawnPlayer();
            InitalizeUI(player);
            InitializeSpawners(player);
        }

        private void SpawnPlayer()
        {
            IInputProvider inputProvider = new PlayerInputActionsWrapper();
            player = playerSpawner.SpawnPlayer(inputProvider);
        }

        private void InitalizeUI(IPlayer player)
        {
            healthBar.Initalize(player);
        }

        private void InitializeSpawners(IPlayer player)
        {
            lightningSpawner.Initalize(player);
        }
    }
}
