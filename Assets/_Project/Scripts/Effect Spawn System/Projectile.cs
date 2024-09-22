using UnityEngine;
using MEC;
using System.Collections.Generic;

namespace TicTacMagic
{
    public class Projectile : MonoBehaviour
    {
        public Vector2 Direction { get{ return direction;} set{ direction = value; LookDirection(); } }
        public float Speed { get; set;}
        public float Damage { get; set; }

        [SerializeField] 
        private SpriteRenderer sprite;

        [SerializeField]
        private float destroyTime = 2f;

        private Rigidbody2D rBody2D;
        private Vector2 direction;

        private IEnumerator<float> _DestroyInTime()
        {            
            yield return Timing.WaitForSeconds(destroyTime);
            Destroy(gameObject);            
        }

        private void LookDirection() {
            if (Direction == Vector2.right)
                sprite.flipX = true;
        }

        private void Awake()
        {
            rBody2D = GetComponent<Rigidbody2D>();

            Timing.RunCoroutine(_DestroyInTime().CancelWith(this.gameObject));
        }

        private void FixedUpdate()
        {
            rBody2D.MovePosition(rBody2D.position + Direction * Speed * Time.fixedDeltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.GetDamage(Damage);
                Destroy(gameObject);
            }
        }
    }
}
