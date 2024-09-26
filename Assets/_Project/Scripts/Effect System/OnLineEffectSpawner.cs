using MEC;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class OnLineEffectSpawner : EffectSpawner
    {
        public event Action OnSpawn;

        [SerializeField] 
        private Transform spawnpoint;
        [SerializeField]
        private Vector2 direction;
        [SerializeField]
        private List<OnLineEffect> effects;        
        [SerializeField]
        public float MinCooldown = 0.5f;
        [SerializeField]
        public float MaxCooldown = 2.0f;

        private OnLineEffectSpawnerView view;
        private EffectPool<OnLineEffect> pool;
        private bool isReady = true;

        private void Start() {
            this.view = GetComponentInChildren<OnLineEffectSpawnerView>();
            this.pool = new EffectPool<OnLineEffect>();
        }

        public override void SpawnWithCooldown() {
            var effect = pool.Get(SelectLineEffectByWeight());

            effect.Initialize(spawnpoint.position);
            effect.RunEffect(direction);
            Timing.RunCoroutine(_Cooldown());
        }

        private IEnumerator<float> _Cooldown() {
            var cooldown = UnityEngine.Random.Range(this.MinCooldown, this.MaxCooldown);

            yield return Timing.WaitForSeconds(cooldown);
            this.isReady = true;
        }

        private OnLineEffect SelectLineEffectByWeight() {
            var effect = SelectEffectByWeight(effects.Cast<IEffect>().ToList());

            return (OnLineEffect)effect;
        }

        private void Update() {
            if( isReady ) {
                this.isReady = false;
                this.view.Blink();
            }
        }

    }
}
