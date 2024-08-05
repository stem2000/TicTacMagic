using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class NonTargetEffectSpawner : EffectSpawner
    {
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private Vector2 spawnDirection;

        public override void SetCurrentStrategy(int waveNumber)
        {
            var wave = waves.FirstOrDefault(wave => wave.number == waveNumber);
            if (wave != null)
            {
                var strategy = wave.factory.Instantiate();
                ((INonTargetStrategy)strategy).Initiliaze(spawnPosition);
                currentStrategy = strategy;
            }
        }

        private void Update()
        {
            if (currentStrategy != null && currentStrategy.ReadyToSpawn)
                currentStrategy.Spawn();
        }
    }
}
