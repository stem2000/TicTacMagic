using System;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "LightningFactory", menuName = "Scriptables/EffectStrategyFacrories/LightningFactory")]
    public class LightningStrategyFactory : EffectStrategyAbstractFactory
    {
        [SerializeField] List<LSFrame> frames;
        public override IStrategy Instantiate()
        {
            var strategy = new GameObject("LightningFactory").AddComponent<LightningStrategy>();
            
            strategy.InitializeFrames(frames);
            return strategy;
        }
    }

    [Serializable]
    public class LSFrame
    {
        public Lightning LightningPrefab;
        public float StartDelay;
        public float EndDelay;
        public float Damage;
    }
}
