using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public abstract class OnLineEffect : MonoBehaviour, IEffect {
        public float Weight => _spawnWeight;

        public bool Disabled => _disabled;

        public Vector2 Direction => _direction;

        public EffectType Type => _type;


        [SerializeField]
        protected float _disableTime = 2f;

        [SerializeField] [Range(0f, 1f)] 
        protected float _spawnWeight = 0.6f;

        [SerializeField]
        protected EffectType _type;

        protected Vector2 _direction;

        protected bool _disabled = true;

        protected string _delayedDisableTag;


        protected virtual void Awake() {
            _delayedDisableTag = gameObject.GetInstanceID().ToString() + "Delayed Disable";
        }

        public abstract void Activate(Vector2 direction);

        protected virtual IEnumerator<float> _DelayedDisable() {
            yield return Timing.WaitForSeconds(_disableTime);
            gameObject.SetActive(false);
        }
    }
}
