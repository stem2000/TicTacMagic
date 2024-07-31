using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class Stone : TileObject
    {
        public override bool IsMoveBlocker() => true;

        public void OnTriggerEnter2D(Collider2D collision)
        {
            IDamageable damageable;

            if(collision.TryGetComponent(out damageable))
                damageable.GetDamage(1000);
        }
    }
}
