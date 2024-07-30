using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "FireSkull", menuName = "Scriptables/ProjectileFactories/FireSkull")]
    public class FireSkullFactory : ProjectileFactory
    {
        [SerializeField] float damage;
        [SerializeField] float speed;
        protected override void SetFactoryStats(Projectile projectile)
        {
            projectile.Damage = damage;
            projectile.Speed = speed;
        }

        public override Projectile Instantiate(Vector3 spawnPosition, Vector2 direction)
        {
            var projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
            SetFactoryStats(projectile);
            projectile.Direction = direction;

            return projectile;
        }
    }
}
