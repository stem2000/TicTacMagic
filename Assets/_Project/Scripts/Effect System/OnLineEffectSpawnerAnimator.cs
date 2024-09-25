using UnityEngine;

namespace TicTacMagic
{
    public class OnLineEffectSpawnerAnimator
    {
        private const string BLINK = "Blink";
        private Animator animator;

        public OnLineEffectSpawnerAnimator(Animator animator) {
            this.animator = animator;
        }

        internal void Blink() {
            this.animator.SetTrigger(BLINK);
        }
    }
}
