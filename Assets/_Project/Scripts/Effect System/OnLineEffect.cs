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
        protected float _disableTime = 2f;

        [SerializeField] [Range(0f, 1f)] 
        protected float _spawnWeight = 0.6f;

        [SerializeField]
        protected EffectType _type;

        protected Vector2 _direction;

        protected string _disableRutineTag;


        private void Awake() {
            _disableRutineTag = gameObject.GetInstanceID().ToString() + "Delayed Disable";
        }

        public abstract void RunEffect(Vector2 direction);

        public void SetSpawnPoint(Vector3 spawnpoint) {
            transform.position = spawnpoint;
        }

        protected virtual IEnumerator<float> _DelayedDisable() {
            yield return Timing.WaitForSeconds(_disableTime);
            gameObject.SetActive(false);
        }

        public void Run() {
            throw new System.NotImplementedException();
        }
    }
}
