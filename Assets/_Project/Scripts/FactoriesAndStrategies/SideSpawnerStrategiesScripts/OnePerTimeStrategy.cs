using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class OnePerTimeStrategy : EffectStrategy, INonTargetStrategy
    {
        [SerializeField] private ProjectileFactory projectileFactory;

        private Transform spawnPoint;
        private Vector2 spawnDirection;

        public float ResetTime { get {return resetTime;} set { resetTime = value;} }

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
