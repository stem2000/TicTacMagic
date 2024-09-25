using System;
using UnityEngine;

namespace TicTacMagic
{    
    public class OnLineEffectSpawnerView : MonoBehaviour
    {
        public event Action OnSpawnTiming;
        OnLineEffectSpawnerAnimator animator;

        private void Awake() {
            var animator = GetComponent<Animator>();

            this.animator = new OnLineEffectSpawnerAnimator(animator);
        }

        public void Blink() {
            this.animator.Blink();
        }

        private void InvokeOnSpawnTiming() {
            OnSpawnTiming?.Invoke();
        }
    }
}
