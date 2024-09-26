using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public abstract class EffectSpawner : MonoBehaviour
    {
        public abstract void SpawnWithCooldown();
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
