using UnityEngine;
using MEC;

namespace TicTacMagic
{
    public class Projectile : LineEffect
    {
        [SerializeField]
        private float _speed = 7;
        [SerializeField]
        public float _damage = 15;
        [SerializeField] 
        private SpriteRenderer _sprite;

        private Rigidbody2D _rBody;

        public override void Run(Vector2 direction) {
            _direction = direction;
            LookDirection();
            Timing.RunCoroutine(_DelayedDestroy().CancelWith(this.gameObject));
        }

        private void LookDirection() {
            if (_direction == Vector2.right)
                _sprite.flipX = true;
        }

        private void Awake()
        {
            _rBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rBody.MovePosition(_rBody.position + _direction * _speed * Time.fixedDeltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.GetDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}
