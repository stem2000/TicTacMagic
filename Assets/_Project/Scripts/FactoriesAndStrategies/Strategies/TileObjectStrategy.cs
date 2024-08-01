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

        private Tile ChoiseTileToSpawn()
        {
            if(frame.TileToSpawnOn != null && CanSpawnOn(frame.TileToSpawnOn))
                return frame.TileToSpawnOn;
            else return GetRandomTile();
        }
        private bool CanSpawnOn(Tile tile)
        {
            if(tile != player.CurrentTile && tile != player.PointedTile && tile.IsFree())
                return true;
            return false;
        }
        private TileObject SpawnTileObject(Tile tile)
        {
            var tileObject = Instantiate(frame.TileObjectPrefab, tile.GetPosition(), Quaternion.identity);

            tile.SetTileObject(tileObject);
            return tileObject;
        }
        private TileMarker SpawnTileMarker(Tile tile)
        {
            var marker = Instantiate(frame.SpawnMarkerPrefab);

            tile.SetTileMarker(marker);
            return marker;
        }
        private void ChangeFrame()
        {
            var index = frames.IndexOf(frame);

            index = (index + 1 <= frames.Count - 1) ? index + 1 : 0;
            frame = frames[index];
        }
        private Tile GetRandomTile()
        {
            var rng = new System.Random();
            var tiles = player.CurrentTile.GetNeighbours().OrderBy(tile => rng.Next()).ToList();

            foreach (var tile in tiles)
                if (CanSpawnOn(tile))
                    return tile;
            return null;
        }
        public void InitializeFrames(List<TOSFrame> frames)
        {
            this.frames = frames;
            frames.ForEach(frame => frame.FindTile());

            frame = frames[0];
        }
        private IEnumerator<float> FrameDelay()
        {
            yield return Timing.WaitForSeconds(frame.StartDelay);
        }
        protected override IEnumerator<float> SpawnerReset()
        {
            yield return Timing.WaitForSeconds(frame.EndDelay);
            ChangeFrame();
            readyToSpawn = true;
        }
        private IEnumerator<float> SpawnWithDelay(Tile tile)
        {
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(FrameDelay()));
            Timing.RunCoroutine(SpawnRoutine(tile));
            Timing.RunCoroutine(SpawnerReset());
        }
        private IEnumerator<float> SpawnRoutine(Tile tile)
        {
            TileMarker marker;
            TileObject tileObject;

            marker = SpawnTileMarker(tile);
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(marker.MarkerTile(frame.MarkerDuration, tile.GetPosition())));

            tileObject = SpawnTileObject(tile);
            Timing.RunCoroutine(tileObject.StartDestroing(frame.TileObjectDuration));
        }
    }
}
