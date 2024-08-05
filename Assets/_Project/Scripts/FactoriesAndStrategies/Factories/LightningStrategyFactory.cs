using System;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "LightningFactory", menuName = "Scriptables/EffectStrategyFacrories/LightningFactory")]
    public class LightningStrategyFactory : EffectStrategyAbstractFactory
    {
        [SerializeField] float initialDelay;
        [SerializeField] List<LSFrame> frames;

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
        public TileObject TileObjectPrefab;
        public float TileObjectSpawnDelay;
        public float TileObjectDuration;
        public Marker MarkerPrefab;
        public float MarkerDuration;
    }
}
