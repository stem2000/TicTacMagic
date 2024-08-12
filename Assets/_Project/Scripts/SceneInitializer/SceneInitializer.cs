using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class SceneInitializer : MonoBehaviour
    {
        [SerializeField] private MusicPlayer musicPlayer;
        [SerializeField] private PlayerSpawner playerSpawner;
        [SerializeField] private WaveController waveController;
        [SerializeField] private GameController gameController;
        [SerializeField] private GameMenuManager menuManager;

        [SerializeField] private HealthBar healthBar;

        [SerializeField] private float topBound;
        [SerializeField] private float bottomBound;
        [SerializeField] private float leftBound;
        [SerializeField] private float rightBound;

        private List<EffectSpawner> effectSpawners;

        private void Start()
        {
            var player = SpawnPlayer();

            InitializeSingletons();
            InitializeGameObjects(player);

            SetupGameObjects();
        }

        private IPlayer SpawnPlayer()
        {
            IDirectionProvider directionProvider = new PlayerInputActionsWrapper();
            return playerSpawner.SpawnPlayer(directionProvider);
        }

        private void InitializeUI(IPlayer player)
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
            if (spawner is LightningSpawner) ((LightningSpawner)spawner).SetupStrategy(player);
            if (spawner is TileObjectSpawner) ((TileObjectSpawner)spawner).SetupStrategy(player);
        }

        private void InitializeWaveController()
        {
            waveController.Initialize(effectSpawners);
            waveController.StartWaves();
        }

        private void InitializeGameController(Player player)
        {
            gameController.SetPlayer(player);
        }

        private void InitializeSingletons()
        {
            TilePromter.Instance.Initialize();
            BoundsPromter.Instance.Initialize(topBound, bottomBound, leftBound, rightBound);
        }

        private void InitializeGameObjects(IPlayer player)
        {
            InitializeEffectSpawners(player);
            InitializeUI(player);
            InitializeWaveController();
            InitializeGameController((Player)player);
        }

        private void SetupGameObjects()
        {
            gameController.OnPauseGame.AddListener(menuManager.OpenPauseMenu);
            gameController.OnPauseGame.AddListener(musicPlayer.Pause);
            gameController.OnUnpauseGame.AddListener(musicPlayer.Play);
            menuManager.OnMenuClosed.AddListener(gameController.UnpauseGame);
        }
    }
}
