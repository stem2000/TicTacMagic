using System;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "TileObjectFactory", menuName = "Scriptables/EffectStrategyFacrories/TileObjectFactory")]
    public class TileObjectStrategyFactory : EffectStrategyAbstractFactory
    {
        [SerializeField] List<TOSFrame> frames;

        public override EffectStrategy Instantiate()
        {
            var strategy = new GameObject("TileObjectStrategy").AddComponent<TileObjectStrategy>();
            strategy.InitializeFrames(frames);
            return strategy;
        }

    }

    [Serializable]
    public class TOSFrame
    {
        public TileObject tileObjectPrefab;
        public float tileObjectDuration;
        public TileMarker spawnMarkerPrefab;
        public float markerDuration;
        public float startDelay;
        public float endDelay;
    }
}
