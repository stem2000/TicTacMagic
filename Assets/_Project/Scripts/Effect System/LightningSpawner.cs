using UnityEngine;
using Zenject;
using MEC;
using System.Collections.Generic;
using System.Linq;

namespace TicTacMagic
{
    public class LightningSpawner : EffectSpawner {

        [SerializeField]
        private List<OnPlayerEffect> effects;

        private EffectPool<OnPlayerEffect> _pool;

        private TileField _tileField;

        private Player _player;


        [Inject]
        public void Construct(TileField tileField, PlayerSpawner playerSpawner) {
            _tileField = tileField;
            playerSpawner.OnPlayerSpawned += SetPlayer;
        }

        private void Start() {
            _pool = new EffectPool<OnPlayerEffect>(transform);
            _pool.Initialize(effects);
        }

        public override void SpawnWithCooldown() {
            var effect = _pool.Get(SelectPlayerEffectByWeight());
                
            effect.Initialize(_player.transform.position);
            effect.Run();
            Timing.RunCoroutine(_Cooldown());
        }

        private OnPlayerEffect SelectPlayerEffectByWeight() {
            var effect = SelectEffectByWeight(effects.Cast<IEffect>().ToList());

            return (OnPlayerEffect)effect;
        }

        private void SetPlayer(Player player) {
            _player = player;
        }

        private void Update() {
            if(_player != null && _isReady) {
                _isReady = false;
                SpawnWithCooldown();
            }
        }
    }
}
