using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class EffectPool<T> where T : MonoBehaviour, IEffect {
        private List<T> effects;


        public EffectPool() { 
            effects = new List<T>();    
        }

        public void Initialize(List<T> effects) {
            foreach (var effect in effects) {
                for(int i = 0; i < effects.Count; i++) { 
                    
                }
            }
        }

        public T Get(T prefab){
            foreach (var effect in effects) { 
                if(effect.Active && effect is T) {
                    return effect;
                }
            }

            return Create(prefab);
        }

        private T Create(T prefab){
            var effect = Object.Instantiate(prefab);

            this.effects.Add(effect);
            return effect;
        }
    }
}
