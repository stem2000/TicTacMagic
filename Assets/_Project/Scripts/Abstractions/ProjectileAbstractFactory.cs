using UnityEngine;

namespace TicTacMagic
{    
    public abstract class ProjectileAbstractFactory : ScriptableObject
    {
        [SerializeField] protected Projectile projectilePrefab;
        protected abstract void SetFactoryStats(Projectile projectile);
        public abstract Projectile Instantiate(Vector3 spawnPosition, Vector2 direction);
    }
}
