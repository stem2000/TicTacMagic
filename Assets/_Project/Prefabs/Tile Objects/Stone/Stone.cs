using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

namespace TicTacMagic
{
    public class Stone : TileEffect
    {
        [SerializeField] float damage = 100f;
        public override bool IsMoveBlocker()
        {
            return true && gameObject.activeSelf;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            IDamageable damageable;

            if(collision.TryGetComponent(out damageable))
                damageable.GetDamage(damage);
        }
    }
}
