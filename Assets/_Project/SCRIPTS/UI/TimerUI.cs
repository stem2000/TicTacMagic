using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TicTacMagic
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI timerText;

        public void UpdateTime(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
