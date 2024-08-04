using System;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "TileObjectFactory", menuName = "Scriptables/EffectStrategyFacrories/TileObjectFactory")]
    public class TileObjectStrategyFactory : EffectStrategyAbstractFactory
    {
        [SerializeField] List<TOSFrame> frames;
        [SerializeField] float initialDelay;

        public override IStrategy Instantiate()
        {
            var strategy = new GameObject("TileObjectStrategy").AddComponent<TileObjectStrategy>();

            strategy.InitializeFrames(frames);
            strategy.InitialDelay = initialDelay;
            return strategy;
        }

    }

    [Serializable]
    public class TOSFrame : Frame
    {
        public TileObject TileObjectPrefab;
        public float TileObjectDuration;
        public TileMarker SpawnMarkerPrefab;
        [HideInInspector] public Tile TileToSpawnOn;
        [SerializeField] private string tileToSpawnOnName;
        public float MarkerDuration;

        public void FindTile()
        {
            var @object = GameObject.Find(tileToSpawnOnName);

            if(@object != null) 
                TileToSpawnOn = @object.GetComponent<Tile>();
        }
    }
}
