using UnityEngine;

namespace TicTacMagic
{
    public class Projectile : MonoBehaviour
    {
        public Vector2 Direction { get{ return direction;} set{ direction = value; LookDirection(); } }
        public float Speed { get; set;}
        public float Damage { get; set; }

        [SerializeField] private SpriteRenderer sprite;
        private Rigidbody2D rBody2D;
        private Vector2 direction;

        private void TryToDeactivate() 
        {
            if(BoundsPromter.Instance.IsOutsideBounds(this))
                Deactivate();
        }

        private void Deactivate()
        {
            Destroy(gameObject);
        }

        private void Awake()
        {
            rBody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rBody2D.MovePosition(rBody2D.position + Direction * Speed * Time.fixedDeltaTime);
            TryToDeactivate();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.GetDamage(Damage);
                Deactivate();
            }
        }

        private void LookDirection()
        {
            if(Direction == Vector2.right)
                sprite.flipX = true;
        }

    }
}
