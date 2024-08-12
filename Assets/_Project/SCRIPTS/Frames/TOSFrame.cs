using System;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    [Serializable]
    public class TOSFrame : Frame
    {
        public TileObject TileObjectPrefab;
        public float TileObjectDuration;
        public Marker MarkerPrefab;
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
