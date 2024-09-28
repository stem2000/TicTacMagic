using MEC;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class OnLineEffectSpawner : EffectSpawner
    {
        public event Action OnSpawn;

        [SerializeField] 
        private Transform _spawnpoint;

        [SerializeField]
        private Vector2 _direction;

        [SerializeField]
        private List<OnLineEffect> _effects; 

        private OnLineEffectSpawnerView _view;

        private EffectPool<OnLineEffect> _pool;


        private void Start() {
            _view = GetComponentInChildren<OnLineEffectSpawnerView>();
            _pool = new EffectPool<OnLineEffect>(this.transform);
        }

        public override void SpawnWithCooldown() {
            var effect = Instantiate(SelectLineEffectByWeight(), _spawnpoint);

            effect.RunEffect(_direction);
            Timing.RunCoroutine(_Cooldown());
        }

        private OnLineEffect SelectLineEffectByWeight() {
            var effect = SelectEffectByWeight(_effects.Cast<IEffect>().ToList());

            return (OnLineEffect)effect;
        }

        private void Update() {
            if( _isReady ) {
                _isReady = false;
                _view.Blink();
            }
        }

    }
}
