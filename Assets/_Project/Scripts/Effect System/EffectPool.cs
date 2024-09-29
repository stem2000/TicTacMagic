using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class EffectPool<T> where T : MonoBehaviour, IEffect {
        private List<T> effects;
        private Transform effectParent;


        public EffectPool(Transform effectParent) { 
            this.effects = new List<T>();  
            this.effectParent = effectParent;
        }

        public void Initialize(List<T> effects) {
            foreach (var effect in effects) {
                for(int i = 0; i < effects.Count; i++) { 
                    this.effects.Add(Create(effect));
                }
            }
        }

        public T Get(T prefab) {
            foreach (var effect in this.effects) { 
                if(!effect.Active && effect.Type == prefab.Type) {
                    return effect;
                }
            }

            return Create(prefab);
        }

        private T Create(T prefab){
            var effect = Object.Instantiate(prefab, effectParent);

            this.effects.Add(effect);
            return effect;
        }
    }
}
