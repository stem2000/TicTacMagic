using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class ProjectileView : MonoBehaviour
    {       
        private SpriteRenderer sRenderer;


        private void Awake() {
            this.sRenderer = GetComponent<SpriteRenderer>();
        }


        public void LookDirection(Vector2 direction) {
            if (direction == Vector2.right) {
                sRenderer.flipX = true;
            }
            if(direction == Vector2.up) {
                var angle = new Vector3(0, 0, -90);
                transform.Rotate(angle);
            }
            if(direction == Vector2.down) {
                var angle = new Vector3(0, 0, 90);
                transform.Rotate(angle);
            }
        }
    }
}
