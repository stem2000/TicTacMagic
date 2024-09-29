using MEC;
using UnityEngine;

namespace TicTacMagic
{
    public class Stone : TileEffect
    {
        [SerializeField] 
        private float _damage = 100f;

        [SerializeField]
        private Collider2D _myCollider;

        private void Awake() {
            _myCollider.enabled = false;
        }

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
            _myCollider.enabled = false;
        }

        protected override void EnableComponents() {
            _view.SetActive(true);
            _myCollider.enabled = true;
        }
    }
}
