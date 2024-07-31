using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "ProjectileFactory", menuName = "Scriptables/EffectStrategyFacrories/ProjectileFactory")]
    public class ProjectileStrategyFactory : EffectStrategyAbstractFactory
    {
        [SerializeField] private FireSkullFactory fireSkullFactory;
        [SerializeField] private float resetTime = 2f;
        public override EffectStrategy Instantiate()
        {
            var strategy = new GameObject("ProjectileFactory").AddComponent<ProjectileStrategy>();  
            
            strategy.resetTime = resetTime;
            strategy.projectileFactory = fireSkullFactory;
            return strategy;
        }
    }
}
