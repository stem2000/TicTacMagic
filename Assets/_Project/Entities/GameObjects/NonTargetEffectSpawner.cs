using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class NonTargetEffectSpawner : EffectSpawner
    {
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private Vector2 spawnDirection;
        public override void Initialize(IPlayer player)
        {
           base.Initialize(player);
        }

        protected override void InitializeStrategies()
        {
            stages.ForEach(stage => ((INonTargetStrategy)stage.strategy).Initiliaze(spawnPosition, spawnDirection));
        }

        private void Update()
        {
            if (currentStrategy.ReadyToSpawn)
                currentStrategy.Spawn();
        }
    }
}
