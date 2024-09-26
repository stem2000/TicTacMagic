using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public abstract class OnLineEffect : MonoBehaviour, IEffect
    {
        public float SpawnWeight => this.spawnWeight;

        public bool Active => this.gameObject.activeSelf;

        [SerializeField]
        protected float destroyTime = 2f;
        [SerializeField] [Range(0f, 1f)] 
        protected float spawnWeight = 0.6f;

        protected Vector2 direction;


        public abstract void RunEffect(Vector2 direction);
        public void Initialize(Vector3 spawnpoint) {
            transform.position = spawnpoint;
        }
        protected IEnumerator<float> _DelayedDestroy() {
            yield return Timing.WaitForSeconds(this.destroyTime);
            Destroy(this.gameObject);
        }
    }
}
