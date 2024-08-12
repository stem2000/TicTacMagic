using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class SceneInitializer : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner playerSpawner;
        [SerializeField] private WaveController waveController;
        [SerializeField] private HealthBar healthBar;

        [SerializeField] private float topBound;
        [SerializeField] private float bottomBound;
        [SerializeField] private float leftBound;
        [SerializeField] private float rightBound;

        private List<EffectSpawner> effectSpawners;

        private void Awake()
        {
            IPlayer player;

            InitializeSingletons();
            player = SpawnPlayer();
            InitalizeUI(player);
            InitializeEffectSpawners(player);
            InitializeWaveController();
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
            effectSpawners = FindObjectsByType<EffectSpawner>(FindObjectsSortMode.None).ToList();
            effectSpawners.ForEach(spawner => InitializeSpawner(spawner, player));
        }

        private void InitializeSpawner(EffectSpawner spawner, IPlayer player)
        {
            if(spawner is LightningSpawner) ((LightningSpawner)spawner).SetPlayer(player);
        }

        private void InitializeWaveController()
        {
            waveController.Initialize(effectSpawners);
            waveController.StartWaves();
        }

        private void InitializeSingletons()
        {
            TilePromter.Instance.Initialize();
            BoundsPromter.Instance.Initialize(topBound, bottomBound, leftBound, rightBound);
        }
    }
}
