using MEC;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class ProjectileStrategy : EffectStrategy, INonTargetStrategy
    {
        private List<PSFrame> frames;
        private PSFrame frame;
        private Transform spawnPoint;

        public void Initiliaze(Transform spawnPoint)
        {
            this.spawnPoint = spawnPoint;
            readyToSpawn = true;
        }

        public override void Spawn()
        {
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

        private IEnumerator<float> SpawnWithDelay()
        {
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(FrameDelay()));
            SpawnProjectile();
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

        internal void InitializeFrames(List<PSFrame> frames)
        {
            this.frames = frames;
            frame = frames[0];
        }

        private void ChangeFrame()
        {
            var index = frames.IndexOf(frame);

            index = (index + 1 <= frames.Count - 1) ? index + 1 : 0;
            frame = frames[index];
        }
    }
}
