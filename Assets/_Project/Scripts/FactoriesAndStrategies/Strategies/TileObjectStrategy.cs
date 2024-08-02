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
            readyToSpawn = true;
        }

        public override void Spawn()
        {
            var tile = ChoiseTileToSpawn();


            if(tile != null && frame != null)
            {
                readyToSpawn = false;
                Timing.RunCoroutine(_SpawnRoutine(tile));
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
            var tiles = player.CurrentTile.GetNeighbours().OrderBy(tile => rng.Next()).ToList();

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
        private IEnumerator<float> _FrameDelay()
        {
            yield return Timing.WaitForSeconds(frame.StartDelay);
        }
        protected override IEnumerator<float> _SpawnerReset()
        {
            yield return Timing.WaitForSeconds(frame.EndDelay);
            ChangeFrame();
            readyToSpawn = true;
        }
        private IEnumerator<float> _SpawnRoutine(Tile tile)
        {
            var tileObject = Instantiate(frame.TileObjectPrefab, tile.GetPosition(), Quaternion.identity);
            tile.PutObjectOnTile(tileObject);

            yield return Timing.WaitUntilDone(Timing.RunCoroutine(_FrameDelay()));
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(_SpawnMarkerRoutine(tile, tileObject)));

            tileObject.Activate();

            Timing.RunCoroutine(tileObject._StartDestroing(frame.TileObjectDuration).CancelWith(tileObject.gameObject));
            Timing.RunCoroutine(_SpawnerReset());
        }
        private IEnumerator<float> _SpawnMarkerRoutine(Tile tile, TileObject tileObject)
        {
            TileMarker marker = Instantiate(frame.SpawnMarkerPrefab);

            yield return Timing.WaitUntilDone(Timing.RunCoroutine(marker._StayOnTile(frame.MarkerDuration, tile.GetPosition())));
        }
    }
}
