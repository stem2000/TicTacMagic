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
            var leftBorder = 0f;
            var rightBorder = 0f;
            var weightPoint = 0f;

            foreach(var effect in effects) {
                totalWeight += effect.Weight;
            }
                
            weightPoint = Random.Range(0f, totalWeight);

            foreach (var effect in effects) {
                rightBorder += effect.Weight;
                if(leftBorder <= weightPoint && weightPoint <= rightBorder) {
                    Debug.Log("pointed weight - " + weightPoint.ToString() + " " + effect.ToString());
                    return effect;
                }
                leftBorder = rightBorder;
            }

            return effects[0];
        }

    }
}
