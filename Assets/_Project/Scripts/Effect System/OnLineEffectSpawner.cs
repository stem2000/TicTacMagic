using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class OnLineEffectSpawner : EffectSpawner
    {
        [SerializeField] 
        private Transform _spawnpoint;
        [SerializeField]
        private Vector2 _direction;
        [SerializeField]
        private List<LineEffect> _effects;        
        [SerializeField]
        public float MinCooldown = 0.5f;
        [SerializeField]
        public float MaxCooldown = 2.0f;

        private LineEffect _lastSpawned;
        private bool _isReady = true;

        public override void Spawn() {
            Timing.RunCoroutine(_Spawn().CancelWith(this.gameObject));
        }

        private IEnumerator<float> _Spawn() {
            _isReady = false;

            var effect = Instantiate(_effects[0], _spawnpoint);
            var cooldown = Random.Range(MinCooldown, MaxCooldown);

            effect.Run(_direction);
            yield return Timing.WaitForSeconds(cooldown);

            _isReady = true;
        }

        private void Update() {
            if( _isReady ) {
                Spawn();
            }
        }

    }
}
