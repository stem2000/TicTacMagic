using UnityEngine;
using MEC;

namespace TicTacMagic
{
    public class Projectile : OnLineEffect
    {
        [SerializeField]
        private float speed = 7;
        [SerializeField]
        public float damage = 15;

        private Rigidbody2D rBody;
        private CircleCollider2D myCollider;
        private ProjectileView view;

        private void Awake() {
            this.rBody = GetComponent<Rigidbody2D>();
            this.myCollider = GetComponent<CircleCollider2D>();
            this.view = GetComponentInChildren<ProjectileView>();
        }

        public override void RunEffect(Vector2 direction) {
            base.direction = direction;

            this.view.LookDirection(direction);
            Timing.RunCoroutine(_DelayedDestroy().CancelWith(this.gameObject));
        }

        protected void DisableEffect() {
            this.myCollider.enabled = false;
            this.speed = 1;
            this.view.Explode();
        }

        private void FixedUpdate()
        {
            this.rBody.MovePosition(this.rBody.position + this.direction * this.speed * Time.fixedDeltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();
            var projectile = collision.gameObject.GetComponent<Projectile>();

            if (damageable != null) {
                damageable.GetDamage(this.damage);
                DisableEffect();
            }

            if(projectile != null) {
                DisableEffect();
            }
        }
    }
}
