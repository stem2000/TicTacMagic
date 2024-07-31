using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class OneProjectilePerTime : EffectStrategy, INonTargetStrategy
    {
        public ProjectileFactory projectileFactory;

        private Transform spawnPoint;
        private Vector2 spawnDirection;

        public new float resetTime;

        public void Initiliaze(Transform spawnPoint, Vector2 spawnDirection)
        {
            this.spawnPoint = spawnPoint;
            this.spawnDirection = spawnDirection;
            readyToSpawn = true;
        }

        public override void Spawn()
        {
            var projectile = projectileFactory.Instantiate(spawnPoint.position, spawnDirection);

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
