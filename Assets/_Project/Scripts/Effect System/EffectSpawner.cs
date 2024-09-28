using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public abstract class EffectSpawner : MonoBehaviour
    {
        [SerializeField]
        public float _minCooldown = 0.5f;

        [SerializeField]
        public float _maxCooldown = 2.0f;

        protected bool _isReady = true;


        public abstract void SpawnWithCooldown();

        protected virtual IEnumerator<float> _Cooldown() {
            var cooldown = Random.Range(_minCooldown, _maxCooldown);

            yield return Timing.WaitForSeconds(cooldown);
            _isReady = true;
        }

        protected virtual IEffect SelectEffectByWeight(List<IEffect> effects) {
            var totalWeight = 0f;
            var pointedWeight = 0f;
            var incrementalWeight = 0f;

            foreach(var effect in effects) {
                totalWeight += effect.SpawnWeight;
            }
                
            pointedWeight = Random.Range(0f, totalWeight);

            foreach (var effect in effects) {
                incrementalWeight += effect.SpawnWeight;
                if(pointedWeight < incrementalWeight) { 
                    return effect;
                }
            }

            return effects[0];
        }

    }
}
