using MEC;
using System;
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
        private List<LineEffect> effects;        
        [SerializeField]
        public float MinCooldown = 0.5f;
        [SerializeField]
        public float MaxCooldown = 2.0f;

        private OnLineEffectSpawnerView view;
        private LineEffect lastSpawned;
        private bool isReady = true;

        private void Start() {
            this.view = GetComponentInChildren<OnLineEffectSpawnerView>();

            view.OnSpawnTiming += Spawn;
        }

        public override void Spawn() {

            Timing.RunCoroutine(_Spawn().CancelWith(this.gameObject));
        }

        public IEnumerator<float> _Spawn() {
            this.isReady = false;

            var effect = Instantiate(this.effects[0], this.spawnpoint);
            var cooldown = UnityEngine.Random.Range(this.MinCooldown, this.MaxCooldown);

            effect.RunOnLine(direction);
            yield return Timing.WaitForSeconds(cooldown);

            this.isReady = true;
        }

        private void Update() {
            if( isReady ) {
                view.Blink();
            }
        }

    }
}
