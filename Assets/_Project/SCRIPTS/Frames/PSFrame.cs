using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
