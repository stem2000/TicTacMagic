using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public abstract class OnPlayerEffect : MonoBehaviour, IEffect
    {
        public float SpawnWeight => spawnWeight;
        public bool Active => this.gameObject.activeSelf;


        [SerializeField] [Range(0f, 1f)]
        protected float spawnWeight = 0.6f;

        [SerializeField]
        protected EffectMarker marker;

        [SerializeField]
        protected float markerDelay;

        public abstract void RunOnPlayer();

        public void DisableEffect() {
            throw new System.NotImplementedException();
        }

        public void EnableEffect() {
            throw new System.NotImplementedException();
        }
    }
}
