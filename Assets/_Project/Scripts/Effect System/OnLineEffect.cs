using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public abstract class OnLineEffect : MonoBehaviour, IEffect {
        public float Weight => _spawnWeight;
        public bool Active => gameObject.activeSelf;
        public EffectType Type => _type;

        [SerializeField]
        protected float _destroyTime = 2f;

        [SerializeField] [Range(0f, 1f)] 
        protected float _spawnWeight = 0.6f;

        [SerializeField]
        protected EffectType _type;

        protected Vector2 _direction;


        public abstract void RunEffect(Vector2 direction);
        public void Initialize(Vector3 spawnpoint) {
            transform.position = spawnpoint;
        }
        protected IEnumerator<float> _DelayedDestroy() {
            yield return Timing.WaitForSeconds(_destroyTime);
            Destroy(gameObject);
        }

        public void Run() {
            throw new System.NotImplementedException();
        }
    }
}
