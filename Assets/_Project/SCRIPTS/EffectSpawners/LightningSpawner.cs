using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace TicTacMagic
{
    public class LightningSpawner : EffectSpawner
    {
        [SerializeField] private List<WaveData<LSFrame>> waveDatas; 
        private LightningStrategy strategy;

        private void Awake()
        {
            strategy = new GameObject("LightningStrategy").AddComponent<LightningStrategy>();
        }

        public void SetupStrategy(IPlayer player)
        {
            strategy.SetPlayer(player);
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
