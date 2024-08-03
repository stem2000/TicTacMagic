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
            readyToSpawn = true;
        }

        public override void Spawn()
        {
            if(frame == null)
                return;

            readyToSpawn = false;
            Timing.RunCoroutine(SpawnWithDelay());
        }

        private void SpawnLightning()
        {
            var lightning = Instantiate(frame.LightningPrefab, player.PlayerPosition, Quaternion.identity);

            lightning.Damage = frame.Damage;
            lightning.Strike();
        }

        private IEnumerator<float> SpawnWithDelay()
        {
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(_RunFrameStartDelay()));
            SpawnLightning();
            Timing.RunCoroutine(_RunFrameEndDelay());
        }
    }
}
