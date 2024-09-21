using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TicTacMagic
{
    public class GetCounterUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI gemCountTMP;

        private void Start()
        { 
            UpdateGemCountUI(0);
        }

        public void UpdateGemCountUI(int currentNumber)
        {
            
        }
    }
}
