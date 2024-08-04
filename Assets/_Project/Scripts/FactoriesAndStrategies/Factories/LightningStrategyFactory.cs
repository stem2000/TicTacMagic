using System;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "LightningFactory", menuName = "Scriptables/EffectStrategyFacrories/LightningFactory")]
    public class LightningStrategyFactory : EffectStrategyAbstractFactory
    {
        [SerializeField] List<LSFrame> frames;
        [SerializeField] float initialDelay;

        public override IStrategy Instantiate()
        {
            var strategy = new GameObject("LightningFactory").AddComponent<LightningStrategy>();
            
            strategy.InitializeFrames(frames);
            strategy.InitialDelay = initialDelay;
            return strategy;
        }
    }

    [Serializable]
    public class LSFrame : Frame
    {
        public Lightning LightningPrefab;
        public float Damage;
    }
}
