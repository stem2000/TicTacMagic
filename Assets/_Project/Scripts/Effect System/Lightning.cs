using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class Lightning : OnPlayerEffect
    {
        [SerializeField]
        private ParticleSystem particles;

        [SerializeField] 
        private CircleCollider2D myCollider;

        [SerializeField]
        private float damage;

        public override void Run() {
            Timing.RunCoroutine(_Run().CancelWith(this.gameObject));
        }

        private IEnumerator<float> _Run()
        {
            yield return Timing.WaitUntilDone(
                Timing.RunCoroutine(this.marker._ShowMarker().CancelWith(this.gameObject))
            );

            EnableEffect();
            yield return Timing.WaitForSeconds(this.particles.main.duration);
            DisableEffect();
        }

        private void EnableEffect() {
            this.myCollider.enabled = true;
            this.particles.gameObject.SetActive(true);
            this.particles.Play();
        }

        private void DisableEffect() {
            this.myCollider.enabled = false;
            this.particles.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            this.myCollider.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.GetDamage(this.damage);
                this.myCollider.enabled = false;
            }
        }
    }
}
