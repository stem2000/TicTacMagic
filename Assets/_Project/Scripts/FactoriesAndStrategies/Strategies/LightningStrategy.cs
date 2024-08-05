using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class LightningStrategy : EffectStrategy<LSFrame>, ITargetStrategy
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

            readyToSpawn = false;
            Timing.RunCoroutine(SpawnWithDelay());
        }

        private void SpawnLightning(Vector2 strikePosition)
        {
            var lightning = Instantiate(frame.LightningPrefab, strikePosition, Quaternion.identity);

            lightning.Damage = frame.Damage;
            lightning.Strike();  
        }

        private IEnumerator<float> _SpawnTileObject(float delay, Vector2 strikePosition)
        {
            yield return Timing.WaitForSeconds(delay);

            var tile = TilePromter.Instance.GetClosestTo(strikePosition);

            if (tile.IsFree())
            {
                var tileObject = Instantiate(frame.TileObjectPrefab, tile.GetPosition(), Quaternion.identity);
                tileObject.Activate();
                Timing.RunCoroutine(tileObject._StartDestroing(frame.TileObjectDuration));
            }
        }

        private IEnumerator<float> _SpawnMarker(Vector2 strikePosition)
        {
            var marker = Instantiate(frame.MarkerPrefab, strikePosition, Quaternion.identity);

            yield return Timing.WaitUntilDone(Timing.RunCoroutine(marker._StayOnSpot(frame.MarkerDuration, strikePosition)));
        }

        private IEnumerator<float> SpawnWithDelay()
        {
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(_RunFrameStartDelay()));

            var strikePosition = player.PlayerPosition;

            yield return Timing.WaitUntilDone(Timing.RunCoroutine(_SpawnMarker(strikePosition)));

            SpawnLightning(strikePosition);

            if (frame.TileObjectPrefab != null)
                Timing.RunCoroutine(_SpawnTileObject(frame.TileObjectSpawnDelay, strikePosition));

            Timing.RunCoroutine(_RunFrameEndDelay());
        }
    }
}
