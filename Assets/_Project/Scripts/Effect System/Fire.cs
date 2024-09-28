using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class Fire : TileEffect
    {
        [SerializeField] 
        private float _damage = 10;

        [SerializeField] 
        private float _damageCooldown = 1f;

        [SerializeField] 
        private CircleCollider2D _myCollider;


        public void OnTriggerEnter2D(Collider2D collision)
        {
            IDamageable damageable;

            if (collision.TryGetComponent(out damageable))
            {
                damageable.GetDamage(_damage);
                Timing.RunCoroutine(_Cooldown().CancelWith(gameObject));
            }
        }

        protected override void EnableComponents() {
            _myCollider.enabled = true;
            _view.SetActive(true);
        }

        protected override void DisableComponents() {
            _myCollider.enabled = false;
            _view.gameObject.SetActive(false);
        }

        private IEnumerator<float> _Cooldown(){
            _myCollider.enabled = false;
            yield return Timing.WaitForSeconds(_damageCooldown);
            _myCollider.enabled = true;
        }

        public override bool IsMoveBlocker() {
            return false;
        }
    }
}
