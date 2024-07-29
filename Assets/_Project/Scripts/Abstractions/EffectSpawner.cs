using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public abstract class EffectSpawner : MonoBehaviour
    {
        [SerializeField] protected List<Stage> stages;
        protected EffectStrategy currentStrategy;
        protected IPlayer player;

        protected abstract void InitializeStrategies();
        public virtual void Initialize(IPlayer player)
        {
            this.player = player;
            SetStrategy(0);
        }

        public void SetStrategy(int stageNumber)
        {
            var stage = stages.FirstOrDefault(s => s.number == stageNumber);
            if (stage != null)
                currentStrategy = stage.strategy;
        }
    }

    [Serializable]
    public class Stage 
    {
        public int number;
        public EffectStrategy strategy;
    }
}
