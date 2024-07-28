using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class LightningSpawner : MonoBehaviour
    {
        [SerializeField] LightningEffect prefab;
        [SerializeField] float resetTime = 2f;
        IPlayer player;
        bool canSpawn = true;

        public void Initalize(IPlayer player)
        {
            this.player = player;
        }

        private void SpawnEffect()
        {
            var effect = Instantiate(prefab, player.PlayerPosition, Quaternion.identity);

            effect.Spawn();
            Timing.RunCoroutine(SpawnerReset());
        }

        private IEnumerator<float> SpawnerReset()
        {
            canSpawn = false;
            yield return Timing.WaitForSeconds(resetTime);
            canSpawn = true;
        }

        private void Update()
        {
            if(canSpawn)
                SpawnEffect();
        }

    }
}
