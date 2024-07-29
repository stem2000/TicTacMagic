using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "OneProjectileStrategy", menuName = "Scriptables/SideStrategies/OneProjectileStrategy")]
    public class OneProjectileStrategy : EffectStrategy, INonTargetStrategy
    {
        [SerializeField] private Projectile projectilePrefab;

        private Transform spawnPoint;
        private Vector2 spawnDirection;

        public void Initiliaze(Transform spawnPosition, Vector2 spawnDirection)
        {
            this.spawnPoint = spawnPosition;
            this.spawnDirection = spawnDirection;
            readyToSpawn = true;
        }

        public override void Spawn()
        {
            var projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
            projectile.direction = spawnDirection;
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
