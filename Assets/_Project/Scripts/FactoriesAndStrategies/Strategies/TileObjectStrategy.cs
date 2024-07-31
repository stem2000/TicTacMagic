using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class TileObjectStrategy : EffectStrategy, ITargetStrategy
    {
        public TileObject tileObjectPrefab;
        public SpawnMarker spawnMarkerPrefab;
        public float markerDuration;

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
                readyToSpawn = false;
                Timing.RunCoroutine(SpawnTileObjectRoutine(tile));
            }
        }

        protected override IEnumerator<float> SpawnerReset()
        {
            yield return Timing.WaitForSeconds(resetTime);
            ClearTileObjects();
            readyToSpawn = true;
        }

        #region OnTileSpawningMethods
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
        private void SpawnTileObject(Tile tile)
        {
            var newTileObject = Instantiate(tileObjectPrefab, tile.GetPosition(), Quaternion.identity);

            tileObjects.Add(newTileObject);
            tile.SetTileObject(newTileObject);

            Timing.RunCoroutine(SpawnerReset());
        }
        private IEnumerator<float> SpawnTileObjectRoutine(Tile tile)
        {
            var marker = Instantiate(spawnMarkerPrefab);
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(marker.SetOnPosition(markerDuration, tile.GetPosition())));
            SpawnTileObject(tile);
        }
        #endregion
    }
}
