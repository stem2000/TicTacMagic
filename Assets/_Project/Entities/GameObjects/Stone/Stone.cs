using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

namespace TicTacMagic
{
    public class Stone : TileObject
    {
        [SerializeField] float damage = 100f;
        public override bool IsMoveBlocker() => true;

        public void OnTriggerEnter2D(Collider2D collision)
        {
            IDamageable damageable;

            if(collision.TryGetComponent(out damageable))
                damageable.GetDamage(damage);
        }
    }
}
