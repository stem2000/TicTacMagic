using System;
using UnityEngine;

namespace TicTacMagic
{    
    public class OnLineEffectSpawnerView : MonoBehaviour
    {
        OnLineEffectSpawnerAnimator animator;
        OnLineEffectSpawner spawner;

        private void Awake() {
            this.spawner = GetComponentInParent<OnLineEffectSpawner>();
            this.animator = new OnLineEffectSpawnerAnimator(GetComponent<Animator>());
        }

        public void Blink() {
            this.animator.Blink();
        }

        private void ae_Spawn() {
            this.spawner.SpawnWithCooldown();
        }
    }
}
