using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class Projectile : MonoBehaviour
    {
        private Rigidbody2D rBody2D;
        private float speed = 3f;
        public Vector2 direction = Vector2.left;

        private void Awake()
        {
            rBody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rBody2D.MovePosition(rBody2D.position + direction * speed * Time.fixedDeltaTime);
        }
    }
}
