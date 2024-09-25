using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public abstract class LineEffect : MonoBehaviour
    {
        public float SpawnWeight => _spawnWeight;

        [SerializeField]
        protected float _destroyTime = 2f;
        [SerializeField] [Range(0f, 1f)] 
        protected float _spawnWeight = 0.6f;

        protected Vector2 _direction;

        public abstract void Run(Vector2 direction);
        protected IEnumerator<float> _DelayedDestroy() {
            yield return Timing.WaitForSeconds(_destroyTime);
            Destroy(gameObject);
        }
    }
}
