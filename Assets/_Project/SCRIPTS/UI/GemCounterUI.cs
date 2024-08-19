using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TicTacMagic
{
    public class GetCounterUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI gemCountTMP;
        [SerializeField] GemCounter gemCounter;

        private void Start()
        {
            gemCounter.OnGemCollected.AddListener(UpdateGemCountUI);  
            UpdateGemCountUI(0);
        }

        public void UpdateGemCountUI(int currentNumber)
        {
            gemCountTMP.text = string.Format("{0}/{1}", currentNumber, gemCounter.NumberToWin);
        }
    }
}
