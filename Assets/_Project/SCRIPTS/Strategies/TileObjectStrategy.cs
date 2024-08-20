using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class TileObjectStrategy : EffectStrategy<TOSFrame>
    {
        public void SetPlayer(IPlayer player)
        {
            this.player = player;
        }

        public override void Spawn()
        {
            if(frame == null)
                return;

            var tile = ChoiseTileToSpawn();

            if(tile != null)
            {
                readyToSpawn = false;
                Timing.RunCoroutine(_Spawn(tile).CancelWith(gameObject));
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
            if (frame.TileToSpawnOn == tile && tile.IsFree())
                return true;
            else if(tile != player.CurrentTile && tile != player.PointedTile && tile.IsFree())
                return true;

            return false;
        }

        private Tile GetRandomTile()
        {
            var rng = new System.Random();
            var tiles = TilePromter.Instance.GetTiles().OrderBy(tile => rng.Next()).ToList();

            foreach (var tile in tiles)
                if (CanSpawnOn(tile))
                    return tile;
            return null;
        }

        public override void InitializeFrames(List<TOSFrame> frames)
        {
            this.frames = frames;
            this.frames.ForEach(frame => frame.FindTile());
            frame = this.frames[0];
        }

        private IEnumerator<float> _SpawnMarkerAndActivateObject(Tile tile, TileObject tileObject)
        {
            var marker = Instantiate(frame.MarkerPrefab);
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(marker._StayOnSpot(frame.MarkerDuration, tile.GetPosition()).CancelWith(marker.gameObject)));
            tileObject.Activate();
            Timing.RunCoroutine(tileObject._StartDestroing(frame.TileObjectDuration).CancelWith(tileObject.gameObject));
        }

        private TileObject SpawnTileObject(Tile tile)
        {
            var tileObject = Instantiate(frame.TileObjectPrefab, tile.GetPosition(), Quaternion.identity);
            tile.MakeUnfreeWith(tileObject);
            return tileObject;
        }

        private IEnumerator<float> _Spawn(Tile tile)
        {
            var tileObject = SpawnTileObject(tile);

            yield return Timing.WaitUntilDone(Timing.RunCoroutine(_RunFrameStartDelay()));
            Timing.RunCoroutine(_SpawnMarkerAndActivateObject(tile, tileObject).CancelWith(gameObject));
            Timing.RunCoroutine(_RunFrameEndDelay());
        }
    }
}
