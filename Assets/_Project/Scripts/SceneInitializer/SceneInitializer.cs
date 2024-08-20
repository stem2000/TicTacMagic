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
        [SerializeField] private GameUIManager uiManager;
        [SerializeField] private GemCounter gemCounter;

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

            SetupGameObjects((Player)player);
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
        }

        private void SetupGameObjects(Player player)
        {
            gameController.SetGemCounter(gemCounter);

            gameController.OnStopGame.AddListener(musicPlayer.Pause);
            gameController.OnRunGame.AddListener(musicPlayer.Play); 
            
            player.AddListenerToPlayerDeath(gameController.HandlePlayerLose);

            waveController.OnTimeIsUp.AddListener(gameController.HandlePlayerWin);
            
            uiManager.LinkToController(gameController);
        }
    }
}
