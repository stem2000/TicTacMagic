using UnityEngine;
using MEC;

namespace TicTacMagic
{
    public class Projectile : LineEffect
    {
        [SerializeField]
        private float speed = 7;
        [SerializeField]
        public float damage = 15;

        private Rigidbody2D rBody;
        private ProjectileView view;

        private void Awake() {
            this.rBody = GetComponent<Rigidbody2D>();
            this.view = GetComponentInChildren<ProjectileView>();
        }

        public override void RunOnLine(Vector2 direction) {
            base.direction = direction;

            this.view.LookDirection(direction);
            Timing.RunCoroutine(_DelayedDestroy().CancelWith(this.gameObject));
        }

        private void FixedUpdate()
        {
            this.rBody.MovePosition(this.rBody.position + this.direction * this.speed * Time.fixedDeltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.GetDamage(this.damage);
                Destroy(this.gameObject);
            }
        }
    }
}
