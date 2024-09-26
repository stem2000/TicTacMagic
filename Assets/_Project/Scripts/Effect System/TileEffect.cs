using System.Collections.Generic;
using UnityEngine;
using MEC;

namespace TicTacMagic {
    public abstract class TileEffect : MonoBehaviour, IEffect {
        public float SpawnWeight => throw new System.NotImplementedException();

        public bool Active => throw new System.NotImplementedException();

        private void Awake()
        {
            gameObject.SetActive(false);
        }
        public abstract bool IsMoveBlocker();
        public virtual void Activate()
        {
            gameObject.SetActive(true);
        }
        public virtual IEnumerator<float> _StartDestroing(float lifetime)
        {
            yield return Timing.WaitForSeconds(lifetime);
            Destroy(gameObject);
        }

        public virtual void DestroyImmediately()
        {
            Destroy(gameObject);
        }

        public float GetWeight() {
            throw new System.NotImplementedException();
        }
    }
}
