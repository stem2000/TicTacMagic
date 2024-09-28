using UnityEngine;

namespace TicTacMagic
{
    public abstract class OnPlayerEffect : MonoBehaviour, IEffect
    {
        public float SpawnWeight => spawnWeight;
        public bool Active => gameObject.activeSelf;  

        [SerializeField] [Range(0f, 1f)]
        protected float spawnWeight = 0.6f;

        [SerializeField]
        protected EffectMarker _marker;


        public void Initialize(Vector3 position) {
            gameObject.transform.position = position;
        }

        public abstract void Run();
    }
}
