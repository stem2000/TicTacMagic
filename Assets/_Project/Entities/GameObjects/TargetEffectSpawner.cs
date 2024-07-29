using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class TargetEffectSpawner : EffectSpawner
    {
        public override void Initialize(IPlayer player)
        {
            base.Initialize(player);
        }

        protected override void InitializeStrategies()
        {
            stages.ForEach(stage => ((ITargetStrategy)stage.strategy).Initalize(player));
        }

        private void Update()
        {
            if (currentStrategy.ReadyToSpawn)
                currentStrategy.Spawn();
        }
    }
}
