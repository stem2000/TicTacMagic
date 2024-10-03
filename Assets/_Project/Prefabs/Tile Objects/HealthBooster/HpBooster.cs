using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class HpBooster : TileEffect
    {
        [SerializeField] 
        float _hp = 15;

        [SerializeField] 
        CircleCollider2D _myCollider;

        private void Awake() {
            DisableComponents();
        }

        public override bool IsMoveBlocker() {
            return false;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            IHealable healable;

            if (collision.TryGetComponent(out healable))
            {
                healable.GetHp(_hp);
                DisableObject();
                Timing.KillCoroutines(_disableRutineTag);
            }
        }

        protected override void DisableComponents() {
            _view.SetActive(false);
            _myCollider.enabled = false;
        }

        protected override void EnableComponents() {
            _view.SetActive(true);
            _myCollider.enabled = true;
        }        
    }
}
