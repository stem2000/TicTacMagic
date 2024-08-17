using UnityEngine;

namespace TicTacMagic
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource mySource;
        
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
    }
}
