using UnityEngine;

namespace TicTacMagic
{
    public abstract class OnPlayerEffect : MonoBehaviour, IEffect
    {
        public float Weight => spawnWeight;
        public bool Disabled => gameObject.activeSelf;
        public EffectType Type => _type;

        [SerializeField] [Range(0f, 1f)]
        protected float spawnWeight = 0.6f;

        [SerializeField]
        protected EffectMarker _marker;

        [SerializeField]
        protected EffectType _type;


        public void Initialize(Vector3 position) {
            gameObject.transform.position = position;
        }

        public abstract void Run();
    }
}
