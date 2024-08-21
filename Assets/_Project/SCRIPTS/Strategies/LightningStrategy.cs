using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class LightningStrategy : EffectStrategy<LSFrame>
    {
        public void SetPlayer(IPlayer player)
        {
            this.player = player;
        }

        public override void Spawn()
        {
            if(frame == null)
                return;

            readyToSpawn = false;
            Timing.RunCoroutine(SpawnWithDelay().CancelWith(gameObject));
        }

        private void SpawnLightning(Vector2 strikePosition)
        {
            var lightning = Instantiate(frame.LightningPrefab, strikePosition, Quaternion.identity);

            lightning.Damage = frame.Damage;
            lightning.Strike();  
        }

        private TileObject SpawnTileObject(Vector2 strikePosition)
        {
            TileObject tileObject = null;
            Tile tile = TilePromter.Instance.GetClosestTo(strikePosition);

            if (tile.IsFree())
            {
                tileObject = Instantiate(frame.TileObjectPrefab, tile.GetPosition(), Quaternion.identity);
                tile.MakeUnfreeWith(tileObject);
            }    

            return tileObject;
        }

        private IEnumerator<float> _SpawnMarker(Vector2 strikePosition)
        {
            var marker = Instantiate(frame.MarkerPrefab, strikePosition, Quaternion.identity);

            yield return Timing.WaitUntilDone(Timing.RunCoroutine(marker._StayOnSpot(frame.MarkerDuration, strikePosition).CancelWith(marker.gameObject)));
        }

        private IEnumerator<float> SpawnWithDelay()
        {
            TileObject tileObject = null;
            Vector2 strikePosition = Vector2.zero;

            yield return Timing.WaitUntilDone(Timing.RunCoroutine(_RunFrameStartDelay()));

            strikePosition = player.PlayerPosition;

            yield return Timing.WaitUntilDone(Timing.RunCoroutine(_SpawnMarker(strikePosition).CancelWith(gameObject)));

            SpawnLightning(strikePosition);

            if (frame.TileObjectPrefab != null)
                tileObject = SpawnTileObject(strikePosition);

            yield return Timing.WaitForSeconds(frame.TileObjectSpawnDelay);

            if(tileObject != null)
            {
                tileObject.Activate();
                Timing.RunCoroutine(tileObject._StartDestroing(frame.TileObjectDuration).CancelWith(tileObject.gameObject));
            }

            Timing.RunCoroutine(_RunFrameEndDelay(), FEDRutineTag);
        }
    }
}
