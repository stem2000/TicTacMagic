using UnityEngine;

namespace TicTacMagic
{
    public class Flying : IState
    {        

        private Rigidbody2D _rBody;

        private CircleCollider2D _collider;

        private ProjectileView _view;

        private Projectile _projectile;


        public Flying(Rigidbody2D rBody, CircleCollider2D collider, ProjectileView view, Projectile projectile) {
            _rBody = rBody;
            _collider = collider;
            _view = view;
            _projectile = projectile;
        }

        public void OnEnter() {
            _collider.enabled = true;
            _view.LookDirection(_projectile.Direction);
            _view.ShowView();
        }

        public void OnExit() {
            _collider.enabled = false;
            _view.HideView();
        }

        public void Tick() {
            _rBody.MovePosition(_rBody.position + _projectile.Direction * _projectile.Speed * Time.fixedDeltaTime);
        }
    }
}
