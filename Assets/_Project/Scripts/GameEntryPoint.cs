using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] PlayerSpawner playerSpawner;
        [SerializeField] List<EffectSpawner> effectSpawners;
        [SerializeField] HealthBar healthBar;

        private void Awake()
        {
            var player = SpawnPlayer();
            InitalizeUI(player);
            InitializeEffectSpawners(player);
        }

        private IPlayer SpawnPlayer()
        {
            IInputProvider inputProvider = new PlayerInputActionsWrapper();
            return playerSpawner.SpawnPlayer(inputProvider);
        }

        private void InitalizeUI(IPlayer player)
        {
            healthBar.Initalize(player);
        }

        private void InitializeEffectSpawners(IPlayer player)
        {
            effectSpawners.ForEach(spawner => spawner.Initialize(player));
        }
    }
}
