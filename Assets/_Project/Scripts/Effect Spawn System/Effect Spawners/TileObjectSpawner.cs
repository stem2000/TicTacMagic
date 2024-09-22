using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class TileObjectSpawner : EffectSpawner
    {
        private bool _readyToSpawn;
        private Player _player;

        public override void Spawn() {
            var tile = ChoiseTileToSpawn();

            if (tile != null) {
                _readyToSpawn = false;
            }

        }
        private Tile ChoiseTileToSpawn() {
            return GetRandomTile();
        }

        private bool CanSpawnOn(Tile tile) {
            if (tile != _player.CurrentTile && tile != _player.PointedTile && tile.IsFree())
                return true;

            return false;
        }

        private Tile GetRandomTile() {
            var rng = new System.Random();
            var tiles = TilePromter.Instance.GetTiles().OrderBy(tile => rng.Next()).ToList();

            foreach (var tile in tiles)
                if (CanSpawnOn(tile))
                    return tile;
            return null;
        }
    }
}
