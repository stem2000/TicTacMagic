using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "TileObjectFactory", menuName = "Scriptables/EffectStrategyFacrories/TileObjectFactory")]
    public class TileObjectStrategyFactory : EffectStrategyAbstractFactory
    {
        [SerializeField] TileObject tileObjectPrefab;
        [SerializeField] SpawnMarker spawnMarkerPrefab;
        [SerializeField] float markerDuration;
        [SerializeField] private float resetTime = 5f;

        public override EffectStrategy Instantiate()
        {
            var strategy = new GameObject("TileObjectStrategy").AddComponent<TileObjectStrategy>();
            strategy.resetTime = resetTime;
            strategy.tileObjectPrefab = tileObjectPrefab;
            strategy.spawnMarkerPrefab = spawnMarkerPrefab;
            strategy.markerDuration = markerDuration;
            return strategy;
        }

    }
}
