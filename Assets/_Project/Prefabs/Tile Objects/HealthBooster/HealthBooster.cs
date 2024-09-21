using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class HealthBooster : TileObject
    {
        [SerializeField] float hpBoost = 15;
        [SerializeField] CircleCollider2D myCollider;

        public override bool IsMoveBlocker()
        {
            return false;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            IHealable healable;

            if (collision.TryGetComponent(out healable))
            {
                healable.GetHp(hpBoost);
                myCollider.enabled = false;
                SelfDestroy();
            }
        }


        private void SelfDestroy()
        {
            Destroy(gameObject);
        }
    }
}
