using System;
using UnityEngine;

namespace TicTacMagic
{
    [Serializable]
    public class PSFrame : Frame
    {
        public Projectile projectilePrefab;
        public Vector2 Direction;
        public float Speed;
        public float Damage;
    }
}
