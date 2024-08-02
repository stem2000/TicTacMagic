using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "LightningStrategy", menuName = "Scriptables/LightningStrategies/LightningStrategy")]
    public class LightningStrategy : EffectStrategy<LSFrame>, ITargetStrategy
    {
        public void Initialize(IPlayer player)
        {
            this.player = player;
            readyToSpawn = true;
        }

        public override void Spawn()
        {
            readyToSpawn = false;
            if (frame != null)
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
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(FrameDelay()));
            SpawnLightning();
            Timing.RunCoroutine(SpawnerReset());
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
    }
}
