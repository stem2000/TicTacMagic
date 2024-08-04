using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "ProjectileFactory", menuName = "Scriptables/EffectStrategyFacrories/ProjectileFactory")]
    public class ProjectileStrategyFactory : EffectStrategyAbstractFactory
    {
        [SerializeField] float initialDelay;
        [SerializeField] List<PSFrame> frames;

        public override IStrategy Instantiate()
        {
            var strategy = new GameObject("ProjectileFactory").AddComponent<ProjectileStrategy>();

            strategy.InitializeFrames(frames);
            strategy.InitialDelay = initialDelay;
            return strategy;
        }
    }

    [Serializable]
    public class PSFrame : Frame
    {
        public Projectile projectilePrefab;
        public Vector2 Direction;
        public float Speed;
        public float Damage;
    }
}
