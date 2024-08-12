using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class ProjectileSpawner : EffectSpawner
    {
        [SerializeField] private List<WaveData<PSFrame>> waveDatas;
        [SerializeField] private Transform spawnPoint;
        private ProjectileStrategy strategy;

        private void Awake()
        {
            strategy = new GameObject("ProjectileStrategy").AddComponent<ProjectileStrategy>();
            strategy.SetupStrategy(spawnPoint);
        }

        public override void SetCurrentStrategy(int waveNumber)
        {
            var waveData = waveDatas.FirstOrDefault(wave => wave.number == waveNumber);

            if (waveData != null)
            {
                strategy.InitializeFrames(waveData.framesPack.frames);
                strategy.InitialDelay = waveData.framesPack.initialDelay;
                strategy.RunInitialDelay();
            }
        }

        private void Update()
        {
            if (strategy != null && strategy.ReadyToSpawn)
                strategy.Spawn();
        }
    }
}
