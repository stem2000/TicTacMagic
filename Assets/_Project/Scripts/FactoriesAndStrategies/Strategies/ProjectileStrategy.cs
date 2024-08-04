using MEC;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class ProjectileStrategy : EffectStrategy<PSFrame>, INonTargetStrategy
    {
        private Transform spawnPoint;

        public void Initiliaze(Transform spawnPoint)
        {
            this.spawnPoint = spawnPoint;
            Timing.RunCoroutine(_RunInitialDelay());
        }

        public override void Spawn()
        {
            if(frame == null) 
                return;

            readyToSpawn = false;
            Timing.RunCoroutine(SpawnWithDelay());
        }

        private void SpawnProjectile()
        {
            var projectile = Instantiate(frame.projectilePrefab, spawnPoint.position, Quaternion.identity);
            projectile.Speed = frame.Speed;
            projectile.Damage = frame.Damage;
            projectile.Direction = frame.Direction;
        }

        protected IEnumerator<float> SpawnWithDelay()
        {
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(_RunFrameStartDelay()));
            SpawnProjectile();
            Timing.RunCoroutine(_RunFrameEndDelay());
        }
    }
}
