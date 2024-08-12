using UnityEngine;

namespace TicTacMagic
{
    public abstract class EffectSpawner : MonoBehaviour
    {
        public abstract void SetCurrentStrategy(int waveNumber);
    }
}
