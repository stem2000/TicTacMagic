using System.Linq;

namespace TicTacMagic
{
    public class TargetEffectSpawner : EffectSpawner
    {
        public override void SetCurrentStrategy(int waveNumber)
        {
            var wave = waves.FirstOrDefault(wave => wave.number == waveNumber);
            if (wave != null)
            {
                var strategy = wave.factory.Instantiate();
                ((ITargetStrategy)strategy).Initialize(player);
                currentStrategy = strategy;
            }
        }

        private void Update()
        {
            if (currentStrategy != null && currentStrategy.ReadyToSpawn)
                currentStrategy.Spawn();
        }
    }
}
