using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class TileObjectStrategy : EffectStrategy<TOSFrame>, ITargetStrategy
    {
        public void Initialize(IPlayer player)
        {
            this.player = player;
            Timing.RunCoroutine(_RunInitialDelay());
        }

        public override void Spawn()
        {
            if(frame == null)
                return;

            var tile = ChoiseTileToSpawn();

            if(tile != null)
            {
                readyToSpawn = false;
                Timing.RunCoroutine(_Spawn(tile));
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
            frames.ForEach(frame => frame.FindTile());
            frame = frames[0];
        }

        private IEnumerator<float> _SpawnMarkerThenActivateObject(Tile tile, TileObject tileObject)
        {
            var marker = Instantiate(frame.SpawnMarkerPrefab);

            yield return Timing.WaitUntilDone(Timing.RunCoroutine(marker._StayOnTile(frame.MarkerDuration, tile.GetPosition())));
            tileObject.Activate();
            Timing.RunCoroutine(tileObject._StartDestroing(frame.TileObjectDuration).CancelWith(tileObject.gameObject));
        }

        private IEnumerator<float> _Spawn(Tile tile)
        {
            var tileObject = Instantiate(frame.TileObjectPrefab, tile.GetPosition(), Quaternion.identity);
            tile.MakeUnfreeWith(tileObject);

            yield return Timing.WaitUntilDone(Timing.RunCoroutine(_RunFrameStartDelay()));
            Timing.RunCoroutine(_SpawnMarkerThenActivateObject(tile, tileObject));
            Timing.RunCoroutine(_RunFrameEndDelay());
        }
    }
}
