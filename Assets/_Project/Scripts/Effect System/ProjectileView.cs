using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class ProjectileView : MonoBehaviour
    {       
        private SpriteRenderer sRenderer;
        private Projectile projectile;
        private ProjectileAnimator animator;


        private void Awake() {
            this.sRenderer = GetComponent<SpriteRenderer>();
            this.projectile = GetComponentInParent<Projectile>();
            this.animator = new ProjectileAnimator(GetComponent<Animator>());
        }


        public void LookDirection(Vector2 direction) {
            if (direction == Vector2.right) {
                this.sRenderer.flipX = true;
            }
        }


        public void Explode() {
            this.animator.Explode();
        }


        private void ae_DisableProjectile() {
            projectile.gameObject.SetActive(false);
        }
    }
}
