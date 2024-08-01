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
                Timing.RunCoroutine(SpawnWithDelay(tile));
            }

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
            var tileObject = Instantiate(frame.tileObjectPrefab, tile.GetPosition(), Quaternion.identity);

            tile.SetTileObject(tileObject);
            Timing.RunCoroutine(tileObject.StartDestroing(frame.tileObjectDuration));
            Timing.RunCoroutine(SpawnerReset());
        }
        #endregion
        private void ChangeFrame()
        {
            var index = frames.IndexOf(frame);

            index = (index + 1 <= frames.Count - 1) ? index + 1 : 0;
            frame = frames[index];
        }
        public void InitializeFrames(List<TOSFrame> frames)
        {
            this.frames = frames;
            frame = frames[0];
        }
        private IEnumerator<float> FrameDelay()
        {
            yield return Timing.WaitForSeconds(frame.startDelay);
        }
        protected override IEnumerator<float> SpawnerReset()
        {
            yield return Timing.WaitForSeconds(frame.endDelay);
            ChangeFrame();
            readyToSpawn = true;
        }
        private IEnumerator<float> SpawnWithDelay(Tile tile)
        {
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(FrameDelay()));
            Timing.RunCoroutine(SpawnRoutine(tile));
        }
        private IEnumerator<float> SpawnRoutine(Tile tile)
        {
            TileObjectMarker marker;

            marker = Instantiate(frame.spawnMarkerPrefab);
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(marker.MarkerTile(frame.markerDuration, tile.GetPosition())));
            SpawnTileObject(tile);
        }
    }
}
