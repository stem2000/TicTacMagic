using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public abstract class LineEffect : MonoBehaviour
    {
        public float SpawnWeight => spawnWeight;

        [SerializeField]
        protected float destroyTime = 2f;
        [SerializeField] [Range(0f, 1f)] 
        protected float spawnWeight = 0.6f;

        protected Vector2 direction;

        public abstract void RunOnLine(Vector2 direction);
        protected IEnumerator<float> _DelayedDestroy() {
            yield return Timing.WaitForSeconds(this.destroyTime);
            Destroy(this.gameObject);
        }
    }
}
