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


        public void Activate(Vector3 position) {
            this.gameObject.SetActive(true);
            this.gameObject.transform.position = position;
        }

        public abstract void Run();
    }
}
