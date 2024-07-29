using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "HauntingLightning", menuName = "Scriptables/LightningStrategies/HauntingLightning")]
    public class HauntingLightningStrategy : SpawnStrategy
    {
        [SerializeField] Lightning prefab;
        [SerializeField] float resetTime = 2f;

        public override void Spawn()
        {
            var lightning = Instantiate(prefab, player.PlayerPosition, Quaternion.identity);

            lightning.Strike();
            Timing.RunCoroutine(SpawnerReset());
        }

        private IEnumerator<float> SpawnerReset()
        {
            readyToSpawn = false;
            yield return Timing.WaitForSeconds(resetTime);
            readyToSpawn = true;
        }
    }
}
