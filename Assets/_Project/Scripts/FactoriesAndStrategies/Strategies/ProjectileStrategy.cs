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
            readyToSpawn = true;
        }
        public override void Spawn()
        {
            readyToSpawn = false;
            if(frame != null)
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
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(FrameDelay()));
            SpawnProjectile();
            Timing.RunCoroutine(_ResetSpawner());
        }
        private IEnumerator<float> FrameDelay()
        {
            yield return Timing.WaitForSeconds(frame.StartDelay);
        }
        protected override IEnumerator<float> _ResetSpawner()
        {
            yield return Timing.WaitForSeconds(frame.EndDelay);
            ChangeFrame();
            readyToSpawn = true;
        }
    }
}
