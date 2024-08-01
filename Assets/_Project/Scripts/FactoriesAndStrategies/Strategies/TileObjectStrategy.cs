using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class TileObjectStrategy : EffectStrategy, ITargetStrategy
    {
        private List<TOSFrame> frames;
        private TOSFrame frame;

        public void Initialize(IPlayer player)
        {
            this.player = player;
            readyToSpawn = true;
        }

        public override void Spawn()
        {
            var tile = ChoiseTileToSpawn();

            if(tile != null)
            {
                readyToSpawn = false;
                Timing.RunCoroutine(SpawnTileObjectRoutine(tile));
            }

            Timing.RunCoroutine(ChangeFrame());
        }

        protected override IEnumerator<float> SpawnerReset()
        {
            yield return Timing.WaitForSeconds(frame.endDelay);
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
        private void SpawnTileObject(Tile tile)
        {
            var newTileObject = Instantiate(frame.tileObjectPrefab, tile.GetPosition(), Quaternion.identity);

            tile.SetTileObject(newTileObject);
            Timing.RunCoroutine(newTileObject.StartDestroing(frame.tileObjectDuration));
            Timing.RunCoroutine(SpawnerReset());
        }
        private IEnumerator<float> SpawnTileObjectRoutine(Tile tile)
        {
            var marker = Instantiate(frame.spawnMarkerPrefab);
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(marker.SetOnPosition(frame.markerDuration, tile.GetPosition())));
            SpawnTileObject(tile);
        }
        #endregion
        private IEnumerator<float> ChangeFrame()
        {
            var index = frames.IndexOf(frame);
            index = (index + 1 <= frames.Count - 1) ? index + 1 : 0;

            yield return Timing.WaitForSeconds(frame.startDelay);

            frame = frames[index];
        }
        public void InitializeFrames(List<TOSFrame> frames)
        {
            this.frames = frames;
            frame = frames[0];
        }
    }
}
