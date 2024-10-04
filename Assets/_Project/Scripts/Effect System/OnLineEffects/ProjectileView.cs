using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class ProjectileView : MonoBehaviour
    {
        [SerializeField]
        private float _explosionDuration = 1f;

        [SerializeField]
        private GameObject _explosion;

        [SerializeField]
        private GameObject _body;

        private SpriteRenderer _sRenderer;

        private Projectile _projectile;


        private void Awake() {
            _sRenderer = GetComponent<SpriteRenderer>();
            _projectile = GetComponent<Projectile>();
        }


        public void LookDirection(Vector2 direction) {
            if (direction == Vector2.right) {
                _sRenderer.flipX = true;
            }
        }

        public void ShowView() {
            _body.SetActive(true);
        }

        public void HideView() {
            _body.SetActive(false);
        }

        public IEnumerator<float> _PlayExplosion() {
            _explosion.SetActive(true);
            yield return Timing.WaitForSeconds(_explosionDuration);
        }
    }
}
