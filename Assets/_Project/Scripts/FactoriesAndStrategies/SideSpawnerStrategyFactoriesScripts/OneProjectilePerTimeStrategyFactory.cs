using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "OnePerTimeFactory", menuName = "Scriptables/EffectStrategyFacrories/OnePerTimeFactory")]
    public class OneProjectilePerTimeStrategyFactory : EffectStrategyAbstractFactory
    {
        [SerializeField] private FireSkullFactory fireSkullFactory;
        [SerializeField] private float resetTime = 2f;
        public override EffectStrategy Instantiate()
        {
            var strategy = new GameObject().AddComponent<OneProjectilePerTime>();  
            
            strategy.resetTime = resetTime;
            strategy.projectileFactory = fireSkullFactory;
            return strategy;
        }
    }
}
