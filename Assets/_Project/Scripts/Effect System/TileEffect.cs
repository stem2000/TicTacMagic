using System.Collections.Generic;
using UnityEngine;
using MEC;

namespace TicTacMagic {
    public abstract class TileEffect : MonoBehaviour, IEffect {
        public float Weight => _spawnWeight;
        public bool Disabled => gameObject.activeSelf;
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

        protected Tile _tile;

        protected string _disableRutineTag;


        private void Awake() {
            gameObject.SetActive(false);

            _disableRutineTag = gameObject.GetInstanceID().ToString() + "Delayed Disable";
        }

        public abstract bool IsMoveBlocker();

        protected virtual void DisableComponents() {
            _view.SetActive(false);
        }

        protected virtual void EnableComponents() {
            _view.SetActive(true);
        }

        protected void FreeTile() {
            _tile.Free();
        }

        protected void UnfreeTile() {
            _tile.UnfreeWith(this);
        }

        public virtual void SetTile(Tile tile) {
            _tile = tile;

            UnfreeTile();
            transform.position = _tile.transform.position;
        }

        public virtual void Run() {
            gameObject.SetActive(true);

            Timing.RunCoroutine(_Run().CancelWith(gameObject));
        }

        protected virtual IEnumerator<float> _Run() {
            yield return Timing.WaitUntilDone(
                Timing.RunCoroutine(_marker._ShowMarker().CancelWith(gameObject))
            );

            EnableComponents();

            Timing.RunCoroutine(_DelayedDisable().CancelWith(gameObject), _disableRutineTag);
        }

        public virtual IEnumerator<float> _DelayedDisable() {
            yield return Timing.WaitForSeconds(_timeOnTile);

            DisableObject();
        }

        protected void DisableObject() {
            FreeTile();
            DisableComponents();
            gameObject.SetActive(false);
        }
    }
}
