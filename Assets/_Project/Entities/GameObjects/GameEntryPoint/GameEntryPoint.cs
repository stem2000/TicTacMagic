using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerSpawner playerSpawner;        
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private BoundsPromter boundsPromter;
        [SerializeField] private TilesPromter tilesPromter;

        private List<EffectSpawner> effectSpawners;

        private void Awake()
        {
            var player = SpawnPlayer();
            InitalizeUI(player);
            InitializeEffectSpawners(player);
            InstantiateSingletons();
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
            effectSpawners.ForEach(spawner => spawner.Initialize(player));
        }

        private void InstantiateSingletons()
        {
            boundsPromter = Instantiate(boundsPromter);
            tilesPromter = Instantiate(tilesPromter);
        }
    }
}
