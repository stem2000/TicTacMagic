using System;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
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
