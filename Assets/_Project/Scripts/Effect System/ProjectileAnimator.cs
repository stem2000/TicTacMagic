using UnityEngine;

namespace TicTacMagic
{
    public class ProjectileAnimator
    {
        private const string EXPLODE = "Explode";
        private Animator animator;

        public ProjectileAnimator(Animator animator) {
            this.animator = animator;
        }

        public void Explode() {
            this.animator.SetTrigger(EXPLODE);
        }
    }
}
