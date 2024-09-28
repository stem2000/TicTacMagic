using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class HealthBooster : TileEffect
    {
        [SerializeField] 
        float _hp = 15;

        [SerializeField] 
        CircleCollider2D _myCollider;

        public override bool IsMoveBlocker() {
            return false;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            IHealable healable;

            if (collision.TryGetComponent(out healable))
            {
                healable.GetHp(_hp);
                _myCollider.enabled = false;
                gameObject.SetActive(false);
            }
        }

        public override void Run() {
            Timing.RunCoroutine(_DelayedDisable().CancelWith(gameObject));
        }
    }
}
