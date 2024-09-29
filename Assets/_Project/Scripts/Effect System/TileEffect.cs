using System.Collections.Generic;
using UnityEngine;
using MEC;

namespace TicTacMagic {
    public abstract class TileEffect : MonoBehaviour, IEffect {
        public float Weight => _spawnWeight;
        public bool Active => gameObject.activeSelf;
        public EffectType Type => _type;

        [SerializeField] [Range(0f, 1f)]
        protected float _spawnWeight = 0.6f;

        [SerializeField]
        protected float _timeOnTile = 2f;

        [SerializeField]
        protected EffectMarker _marker;

        [SerializeField]
        protected GameObject _view;

        [SerializeField]
        protected EffectType _type;

        protected Tile _tilespot;


        public abstract bool IsMoveBlocker();

        protected virtual void DisableComponents() {
            _view.SetActive(false);
        }

        protected virtual void EnableComponents() {
            _view.SetActive(true);
        }

        protected void FreeTilespot() {
            _tilespot.Free();
        }

        protected void UnfreeTilespot() {
            _tilespot.UnfreeWith(this);
        }

        private void Awake() {
            gameObject.SetActive(false);
        }

        public virtual void Initialize(Tile tile) {
            _tilespot = tile;

            UnfreeTilespot();
            transform.position = _tilespot.transform.position;
        }

        public virtual void Run() {
            gameObject.SetActive(true);

            Timing.RunCoroutine(_Run().CancelWith(gameObject));
        }

        public virtual IEnumerator<float> _DelayedDisable() {
            yield return Timing.WaitForSeconds(_timeOnTile);

            FreeTilespot();
            DisableComponents();
            gameObject.SetActive(false);
        }

        protected virtual IEnumerator<float> _Run() {
            yield return Timing.WaitUntilDone(
                Timing.RunCoroutine(_marker._ShowMarker().CancelWith(gameObject))
            );

            EnableComponents();

            Timing.RunCoroutine(_DelayedDisable().CancelWith(gameObject));
        }

    }
}
