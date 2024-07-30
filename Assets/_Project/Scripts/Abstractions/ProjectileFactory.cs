using UnityEngine;

namespace TicTacMagic
{    
    public abstract class ProjectileFactory : ScriptableObject
    {
        [SerializeField] protected Projectile projectilePrefab;
        protected abstract void SetFactoryStats(Projectile projectile);
        public abstract Projectile Instantiate(Vector3 spawnPosition, Vector2 direction);
    }
}
