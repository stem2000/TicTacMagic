using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class Lightning : OnPlayerEffect
    {
        [SerializeField] 
        private ParticleSystem lightningPS;

        [SerializeField] 
        private CircleCollider2D myCollider;

        [SerializeField]
        private float damage;

        public override void RunOnPlayer() {
            Timing.RunCoroutine(_StrikeRoutine().CancelWith(this.gameObject));
        }

        private IEnumerator<float> _StrikeRoutine()
        {
            this.myCollider.enabled = true;

            var marker = Instantiate(this.marker, this.transform);
            yield return Timing.WaitForSeconds(this.markerDelay);
            Destroy(marker);

            Instantiate(this.lightningPS, this.transform);
            yield return Timing.WaitForSeconds(this.lightningPS.main.duration);
            Destroy(this.gameObject);
        }

        private void Awake()
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
