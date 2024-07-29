using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "HauntingLightning", menuName = "Scriptables/LightningStrategies/HauntingLightning")]
    public class HauntingLightningStrategy : EffectStrategy, ITargetStrategy
    {
        [SerializeField] Lightning prefab;

        public void Initalize(IPlayer player)
        {
            this.player = player;
            readyToSpawn = true;
        }

        public override void Spawn()
        {
            var lightning = Instantiate(prefab, player.PlayerPosition, Quaternion.identity);

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
