using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource mySource;
        [SerializeField] private int startPlayFadeDuration = 3;

        private void Start()
        {
            SlowPlay();
        }

        public void SlowPlay()
        {
            Timing.RunCoroutine(_PlaySlow());
        }

        public void Play()
        {
            mySource.Play();
        }

        public void Pause()
        {
            mySource.Pause();
        }

        public void Stop()
        {
            mySource.Stop();
        }

        private IEnumerator<float> _PlaySlow()
        {
            float currentTime = 0f;
            mySource.volume = 0f;
            Play();

            while (currentTime < startPlayFadeDuration)
            {
                currentTime += Time.deltaTime;
                mySource.volume = Mathf.Lerp(0f, 1f, currentTime / startPlayFadeDuration);
                yield return Timing.WaitForOneFrame;
            }

            mySource.volume = 1f;
        }
    }
}
