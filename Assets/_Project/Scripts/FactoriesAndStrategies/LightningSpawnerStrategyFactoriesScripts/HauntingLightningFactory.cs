using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "HauntingLightningFactory", menuName = "Scriptables/EffectStrategyFacrories/HauntingLightningFactory")]
    public class HauntingLightningFactory : EffectStrategyAbstractFactory
    {
        [SerializeField] HauntingLightningStrategy strategyPrefab;
        [SerializeField] private float resetTime = 2f;
        public override EffectStrategy Instantiate()
        {
            var strategy = Instantiate(strategyPrefab);
            strategy.ResetTime = resetTime;
            return strategy;
        }
    }
}
