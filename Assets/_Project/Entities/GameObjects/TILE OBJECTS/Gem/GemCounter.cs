using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public class GemCounter : MonoBehaviour
    {
        [SerializeField] private int numberToWin = 3;
        [HideInInspector] public UnityEvent<int> OnGemCollected;

        private int currentGemNumber;

        public int NumberToWin => numberToWin;

        private void Start()
        {
            Gem.OnCollect.AddListener(HandleCollectedGem);
        }

        private void HandleCollectedGem()
        {
            currentGemNumber += 1;
            OnGemCollected?.Invoke(currentGemNumber);
        }
    }
}
