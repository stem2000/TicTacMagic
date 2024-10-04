using UnityEngine;
using MEC;
using System.Collections.Generic;

namespace TicTacMagic
{
    public class Projectile : OnLineEffect
    {
        public float Speed => _speed;
        public float DisableTime => _disableTime;

        [SerializeField]
        private float _speed = 7;

        [SerializeField]
        public float _damage = 15;

        private Rigidbody2D _rBody;

        private CircleCollider2D _collider;

        private ProjectileView _view;

        private StateMachine _stateMachine;


        protected override void Awake() {
            base.Awake();

            _rBody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<CircleCollider2D>();
            _view = GetComponent<ProjectileView>();

            _stateMachine = new StateMachine();

            var disabled = new Disabled(this);
            var flying = new Flying(_rBody, _collider, _view, this);

            _stateMachine.SetState(disabled);

            _stateMachine.AddTransition(disabled, flying, () => !_disabled);
            _stateMachine.AddTransition(flying, disabled, () => _disabled);
        }

        private void Update() {
            _stateMachine.Tick();
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            var damageable = collision.gameObject.GetComponent<IDamageable>();
            var projectile = collision.gameObject.GetComponent<Projectile>();

            if (damageable != null) {
                damageable.GetDamage(_damage);
                _disabled = true;
            }

            if (projectile != null) {
                _disabled = true;
            }
        }

        public override void Activate(Vector2 direction) {
            _direction = direction;
            _disabled = false;

            Timing.RunCoroutine(_DelayedDisable().CancelWith(gameObject));
        }

        public void KillRoutines() {
            Timing.KillCoroutines(_delayedDisableTag);
        }

        protected override IEnumerator<float> _DelayedDisable() {
            yield return Timing.WaitForSeconds(_disableTime);
            _disabled = true;
        }
    }
}
