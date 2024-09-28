using MEC;
using UnityEngine;

namespace TicTacMagic
{
    public class Stone : TileEffect
    {
        [SerializeField] 
        float _damage = 100f;        

        public void OnTriggerEnter2D(Collider2D collision)
        {
            IDamageable damageable;

            if(collision.TryGetComponent(out damageable))
                damageable.GetDamage(_damage);
        }

        public override bool IsMoveBlocker() {
            return _view.activeSelf;
        }

        protected override void DisableComponents() {
            _view.SetActive(false);
        }

        protected override void EnableComponents() {
            _view.SetActive(true);
        }
    }
}
