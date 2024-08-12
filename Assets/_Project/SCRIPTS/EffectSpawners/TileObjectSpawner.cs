using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class TileObjectSpawner : EffectSpawner
    {
        [SerializeField] private List<WaveData<TOSFrame>> waveDatas;
        private TileObjectStrategy strategy;

        private void Awake()
        {
            strategy = new GameObject("TileObjectStrategy").AddComponent<TileObjectStrategy>();
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
