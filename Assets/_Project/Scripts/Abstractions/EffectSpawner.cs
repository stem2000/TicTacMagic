using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class EffectSpawner : MonoBehaviour
    {
        [SerializeField] private List<Stage> stages;
        private IPlayer player;       
        private SpawnStrategy currentStrategy;

        public void Initialize(IPlayer player)
        {
            this.player = player;
            InitializeStrategies(player);
            SetStrategy(0);
        }

        public void SetStrategy(int stageNumber)
        {
            var stage = stages.FirstOrDefault(s => s.number == stageNumber);
            if (stage != null)
                currentStrategy = stage.strategy;
        }

        private void InitializeStrategies(IPlayer player) 
        {
            stages.ForEach(stage => stage.strategy.Initialize(player));
        }

        private void Update()
        {
            if(currentStrategy.ReadyToSpawn)
                currentStrategy.Spawn();
        }
    }

    [Serializable]
    public class Stage 
    {
        public int number;
        public SpawnStrategy strategy;
    }
}
