using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "ProjectileFactory", menuName = "Scriptables/EffectStrategyFacrories/ProjectileFactory")]
    public class ProjectileStrategyFactory : EffectStrategyAbstractFactory
    {
        [SerializeField] List<PSFrame> frames;

        public override EffectStrategy Instantiate()
        {
            var strategy = new GameObject("ProjectileFactory").AddComponent<ProjectileStrategy>();
            strategy.InitializeFrames(frames);
            return strategy;
        }
    }

    [Serializable]
    public class PSFrame
    {
        public Projectile projectilePrefab;
        public Vector2 Direction;
        public float Speed;
        public float Damage;
        public float StartDelay;
        public float EndDelay;
    }
}
