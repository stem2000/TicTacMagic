using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class Fire : TileObject
    {
        [SerializeField] float damage = 10;
        [SerializeField] float damageCooldown = 1f;
        [SerializeField] CircleCollider2D myCollider;

        public override bool IsMoveBlocker()
        {
            return false;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            IDamageable damageable;

            if (collision.TryGetComponent(out damageable))
            {
                damageable.GetDamage(damage);
                Timing.RunCoroutine(StartCooldown().CancelWith(gameObject));
            }
        }

        private IEnumerator<float> StartCooldown()
        {
            myCollider.enabled = false;
            yield return Timing.WaitForSeconds(damageCooldown);
            myCollider.enabled = true;
        }
    }
}
