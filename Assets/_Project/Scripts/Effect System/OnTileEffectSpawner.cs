using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace TicTacMagic
{
    public class OnTileEffectSpawner : EffectSpawner
    {
        private bool isReady;
        private Player player;
        private TileField tileField;


        [Inject]
        public void Construct(TileField tileField) {
            this.tileField = tileField;
        }

        public override void SpawnWithCooldown() {
            var tile = ChoiseTileToSpawn();

            if (tile != null) {
                isReady = false;
            }

        }

        private Tile ChoiseTileToSpawn() {
            return GetRandomTile();
        }


        private bool CanSpawnOn(Tile tile) {
            if (tile != player.CurrentTile && tile != player.PointedTile && tile.IsFree())
                return true;

            return false;
        }


        private Tile GetRandomTile() {
            var rng = new System.Random();
            var tiles = tileField.GetTiles().OrderBy(tile => rng.Next()).ToList();

            foreach (var tile in tiles)
                if (CanSpawnOn(tile))
                    return tile;
            return null;
        }
    }
}
