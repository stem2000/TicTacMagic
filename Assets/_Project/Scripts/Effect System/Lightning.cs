using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class Lightning : OnPlayerEffect
    {
        [SerializeField]
        private ParticleSystem _particles;

        [SerializeField] 
        private CircleCollider2D _myCollider;

        [SerializeField]
        private float _damage;

        public override void Run() {
            gameObject.SetActive(true);

            Timing.RunCoroutine(_Run().CancelWith(gameObject));
        }

        private IEnumerator<float> _Run()
        {
            yield return Timing.WaitUntilDone(
                Timing.RunCoroutine(_marker._ShowMarker().CancelWith(gameObject))
            );

            EnableComponents();

            yield return Timing.WaitForSeconds(_particles.main.duration);

            DisableComponents();
            gameObject.SetActive(false);
        }

        private void EnableComponents() {
            _myCollider.enabled = true;
            _particles.gameObject.SetActive(true);
            _particles.Play();
        }

        private void DisableComponents() {
            _myCollider.enabled = false;
            _particles.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _myCollider.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.GetDamage(_damage);
                _myCollider.enabled = false;
            }
        }
    }
}
