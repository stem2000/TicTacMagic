using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class OneTileObjectPerTime : EffectStrategy, ITargetStrategy
    {
        public TileObject tileObjectPrefab;
        public List<TileObject> tileObjects;
        public new float resetTime;

        public void Initialize(IPlayer player)
        {
            this.player = player;
            readyToSpawn = true;
            tileObjects = new List<TileObject>();
        }

        public override void Spawn()
        {
            var tile = ChoiseTileToSpawn();

            if(tile != null)
            {
                var newTileObject = Instantiate(tileObjectPrefab, tile.GetPosition(), Quaternion.identity);

                tileObjects.Add(newTileObject);
                tile.SetTileObject(newTileObject);

                Timing.RunCoroutine(SpawnerReset());
            }
        }

        protected override IEnumerator<float> SpawnerReset()
        {
            readyToSpawn = false;
            yield return Timing.WaitForSeconds(resetTime);
            ClearTileObjects();
            readyToSpawn = true;
        }

        private Tile ChoiseTileToSpawn()
        {
            var rng = new System.Random();
            var tiles = player.CurrentTile.GetNeighbours().OrderBy(tile => rng.Next()).ToList();

            foreach(var tile in tiles)           
                if(CanSpawnOn(tile))
                    return tile;
            return null;
        }

        private bool CanSpawnOn(Tile tile)
        {
            if(tile != player.CurrentTile && tile != player.PointedTile && tile.IsFree())
                return true;
            return false;
        }

        private void ClearTileObjects()
        {
            tileObjects.ForEach(stone => Destroy(stone.gameObject));
            tileObjects.Clear();
        }
    }
}
