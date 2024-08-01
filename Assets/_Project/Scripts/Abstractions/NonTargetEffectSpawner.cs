using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class NonTargetEffectSpawner : EffectSpawner
    {
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private Vector2 spawnDirection;

        public override void SetCurrentStrategy(int stageNumber)
        {
            var stage = stages.FirstOrDefault(stage => stage.number == stageNumber);
            if (stage != null)
            {
                var strategy = stage.factory.Instantiate();
                ((INonTargetStrategy)strategy).Initiliaze(spawnPosition, spawnDirection);
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
