using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class Lightning : MonoBehaviour
    {
        [SerializeField] ParticleSystem lightning;
        [SerializeField] CircleCollider2D myCollider;
        [HideInInspector] public float Damage;
        
        public void Strike()
        {
            Timing.RunCoroutine(StrikeRoutine());
        }

        private IEnumerator<float> StrikeRoutine()
        {
            myCollider.enabled = true;

            Instantiate(lightning, transform).Play();
            yield return Timing.WaitForSeconds(lightning.main.duration);

            Destroy(gameObject);
        }

        private void Awake()
        {
            myCollider.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.GetDamage(Damage);
                myCollider.enabled = false;
            }
        }
    }
}
