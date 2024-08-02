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
        protected IStrategy currentStrategy;
        protected IPlayer player;

        public virtual void Initialize(IPlayer player)
        {
            this.player = player;
            if(stages.Count > 0)
                SetCurrentStrategy(0);
        }

        public abstract void SetCurrentStrategy(int stageNumber);
    }

    [Serializable]
    public class Stage 
    {
        public int number;
        public EffectStrategyAbstractFactory factory;
    }
}
