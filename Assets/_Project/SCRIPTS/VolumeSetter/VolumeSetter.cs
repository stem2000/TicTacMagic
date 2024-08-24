using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace TicTacMagic
{
    public class VolumeSetter : MonoBehaviour
    {
        [SerializeField] private Slider volumeSlider;
        [SerializeField] private AudioMixer audioMixer;

        private string musicKey = "musicVolume";

        void Awake()
        {
            if (PlayerPrefs.HasKey(musicKey))
                LoadVolume();
            else
            {
                PlayerPrefs.SetFloat(musicKey, 0.3f);
                LoadVolume();
            }
        }

        public void SetVolume()
        {
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(volumeSlider.value) * 20);
            SaveVolume();
        }

        private void SaveVolume()
        {
            PlayerPrefs.SetFloat(musicKey, volumeSlider.value);
        }

        private void LoadVolume()
        {
            volumeSlider.value = PlayerPrefs.GetFloat(musicKey);
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(volumeSlider.value) * 20);
        }

    }
}
