using UnityEngine;

namespace TicTacMagic
{
    public class Projectile : MonoBehaviour
    {
        private Rigidbody2D rBody2D;
        public Vector2 Direction { get; set;}
        public float Speed { get; set;}
        public float Damage { get; set; }

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

    }
}
