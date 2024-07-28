using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class LightningEffect : MonoBehaviour
    {
        [SerializeField] ParticleSystem preLightning;
        [SerializeField] ParticleSystem lightning;
        [SerializeField] CircleCollider2D effectCollider;
        [SerializeField] float damage = 30;
        
        public void Spawn()
        {
            Timing.RunCoroutine(SpawnRoutine());
        }

        private IEnumerator<float> SpawnRoutine()
        {
            PlayParticles(preLightning);
            yield return Timing.WaitForSeconds(preLightning.main.duration);

            effectCollider.enabled = true;

            PlayParticles(lightning);
            yield return Timing.WaitForSeconds(lightning.main.duration);

            Destroy(gameObject);
        }

        private void PlayParticles(ParticleSystem particles) 
        {
            var newParticles = Instantiate(particles, transform);
            var cullingMode = newParticles.main.cullingMode;
            cullingMode = ParticleSystemCullingMode.AlwaysSimulate;
            newParticles.Play();
        }

        private void Awake()
        {
            effectCollider.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
                damageable.GetDamage(damage);
        }
    }
}
