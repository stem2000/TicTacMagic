using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class Lightning : MonoBehaviour
    {
        [SerializeField] ParticleSystem preLightning;
        [SerializeField] ParticleSystem lightning;
        [SerializeField] CircleCollider2D collider;
        public float damage = 30;
        
        public void Strike()
        {
            Timing.RunCoroutine(StrikeRoutine());
        }

        private IEnumerator<float> StrikeRoutine()
        {
            Instantiate(preLightning, transform).Play();
            yield return Timing.WaitForSeconds(preLightning.main.duration);

            collider.enabled = true;

            Instantiate(lightning, transform).Play();
            yield return Timing.WaitForSeconds(lightning.main.duration);

            Destroy(gameObject);
        }

        private void Awake()
        {
            collider.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.GetDamage(damage);
                collider.enabled = false;
            }
        }
    }
}
