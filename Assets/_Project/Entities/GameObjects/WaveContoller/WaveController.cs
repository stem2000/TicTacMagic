using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public class WaveController : MonoBehaviour
    {
        [SerializeField] private List<Wave> waves;
        [SerializeField] private float workTime;
        [SerializeField] private UnityEvent OnTimeIsUp;
        [SerializeField] private UnityEvent<float> OnTimeChanged;

        private List<EffectSpawner> effectSpawners;
        private Timer timer;
        private int currentWave;
        private bool CanStartWaves;
   

        public void Initialize(List<EffectSpawner> effectSpawners)
        {
            this.effectSpawners = effectSpawners;
        }

        public void StartWaves()
        {
            CanStartWaves = true;

            timer = new GameObject().AddComponent<Timer>();
            timer.ResetTimer(workTime);
        }

        private void TryToStartWave()
        {
            if(currentWave <= waves.Count - 1 && waves[currentWave].startTime >= timer.GetTime())
            {
                SetWaveInSpawners(currentWave);
                currentWave += 1;
            } 
        }

        private void SetWaveInSpawners(int waveNumber)
        {
            foreach(var spawner in effectSpawners)
            {
                spawner.SetCurrentStrategy(waveNumber);
            }
        }

        private void Update()
        {
            if (CanStartWaves)
            {
                TryToStartWave();
                OnTimeChanged?.Invoke(timer.GetTime());
            }
        }
    }
}
