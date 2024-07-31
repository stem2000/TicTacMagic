using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "OneTileObjectPerTimeFactory", menuName = "Scriptables/EffectStrategyFacrories/OneStonePerTimeFactory")]
    public class OneTileObjectPerTimeFactory : EffectStrategyAbstractFactory
    {
        [SerializeField] TileObject tileObjectPrefab;
        [SerializeField] private float resetTime = 5f;

        public override EffectStrategy Instantiate()
        {
            var strategy = new GameObject("OneTileObjectPerTimeEffectStrategy").AddComponent<OneTileObjectPerTime>();
            strategy.resetTime = resetTime;
            strategy.tileObjectPrefab = tileObjectPrefab;
            return strategy;
        }

    }
}
