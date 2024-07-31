using System.Linq;

namespace TicTacMagic
{
    public class TargetEffectSpawner : EffectSpawner
    {
        public override void SetCurrentStrategy(int stageNumber)
        {
            var stage = stages.FirstOrDefault(stage => stage.number == stageNumber);
            if (stage != null)
            {
                var strategy = stage.factory.Instantiate();
                ((ITargetStrategy)strategy).Initialize(player);
                currentStrategy = strategy;
            }
        }

        private void Update()
        {
            if (currentStrategy.ReadyToSpawn)
                currentStrategy.Spawn();
        }
    }
}
