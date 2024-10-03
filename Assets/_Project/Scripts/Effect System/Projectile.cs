using UnityEngine;
using MEC;
using System.Collections.Generic;

namespace TicTacMagic
{
    public class Projectile : OnLineEffect
    {
        [SerializeField]
        private float _speed = 7;
        [SerializeField]
        public float _damage = 15;

        private Rigidbody2D _rBody;
        private CircleCollider2D _myCollider;
        private ProjectileView _view;

        private void Awake() {
            _rBody = GetComponent<Rigidbody2D>();
            _myCollider = GetComponent<CircleCollider2D>();
            _view = GetComponentInChildren<ProjectileView>();
        }

        private void OnEnable() {
            EnableObject();
        }

        private void FixedUpdate() {
            _rBody.MovePosition(_rBody.position + _direction * _speed * Time.fixedDeltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            var damageable = collision.gameObject.GetComponent<IDamageable>();
            var projectile = collision.gameObject.GetComponent<Projectile>();

            if (damageable != null) {
                damageable.GetDamage(_damage);
                DisableObject();
                Timing.KillCoroutines(_disableRutineTag);
            }

            if (projectile != null) {
                DisableObject();
                Timing.KillCoroutines(_disableRutineTag);
            }
        }

        public override void RunEffect(Vector2 direction) {
            _direction = direction;

            _view.LookDirection(direction);
            Timing.RunCoroutine(_DelayedDisable().CancelWith(gameObject));
        }

        protected override IEnumerator<float> _DelayedDisable() {
            yield return Timing.WaitForSeconds(_disableTime);

            DisableObject();
        }

        private void DisableObject() {
            _myCollider.enabled = false;
            _view.Explode();
        }

        private void EnableObject() {
            _myCollider.enabled = true;
        }
    }
}
