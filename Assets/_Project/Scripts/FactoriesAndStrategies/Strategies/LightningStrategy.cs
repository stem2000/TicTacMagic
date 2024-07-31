using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "LightningStrategy", menuName = "Scriptables/LightningStrategies/LightningStrategy")]
    public class LightningStrategy : EffectStrategy, ITargetStrategy
    {
        public LightningProjectile lightningPrefab;

        public float ResetTime { get { return resetTime; } set { resetTime = value; } }

        public void Initialize(IPlayer player)
        {
            this.player = player;
            readyToSpawn = true;
        }

        public override void Spawn()
        {
            var lightning = Instantiate(lightningPrefab, player.PlayerPosition, Quaternion.identity);

            lightning.Strike();
            Timing.RunCoroutine(SpawnerReset());
        }

        protected override IEnumerator<float> SpawnerReset()
        {
            readyToSpawn = false;
            yield return Timing.WaitForSeconds(resetTime);
            readyToSpawn = true;
        }
    }
}
