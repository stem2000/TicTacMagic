using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "HauntingLightningFactory", menuName = "Scriptables/EffectStrategyFacrories/HauntingLightningFactory")]
    public class HauntingLightningFactory : EffectStrategyAbstractFactory
    {
        [SerializeField] LightningProjectile lightningPrefab;
        [SerializeField] private float resetTime = 2f;
        public override EffectStrategy Instantiate()
        {
            var strategy = new GameObject().AddComponent<HauntingLightningStrategy>();
            
            strategy.ResetTime = resetTime;
            strategy.lightningPrefab = lightningPrefab;
            return strategy;
        }
    }
}
