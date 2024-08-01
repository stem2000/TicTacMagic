using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "LightningFactory", menuName = "Scriptables/EffectStrategyFacrories/LightningFactory")]
    public class LightningStrategyFactory : EffectStrategyAbstractFactory
    {
        [SerializeField] Lightning lightningPrefab;
        [SerializeField] private float resetTime = 2f;
        public override EffectStrategy Instantiate()
        {
            var strategy = new GameObject("LightningFactory").AddComponent<LightningStrategy>();
            
            strategy.ResetTime = resetTime;
            strategy.lightningPrefab = lightningPrefab;
            return strategy;
        }
    }
}
