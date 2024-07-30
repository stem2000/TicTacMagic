using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "OnePerTimeFactory", menuName = "Scriptables/EffectStrategyFacrories/OnePerTimeFactory")]
    public class OnePerTimeStrategyFactory : EffectStrategyAbstractFactory
    {
        [SerializeField] private OnePerTimeStrategy strategyPrefab;
        [SerializeField] private float resetTime = 2f;
        public override EffectStrategy Instantiate()
        {
            var strategy = Instantiate(strategyPrefab);   
            strategy.ResetTime = resetTime;
            return strategy;
        }
    }
}
