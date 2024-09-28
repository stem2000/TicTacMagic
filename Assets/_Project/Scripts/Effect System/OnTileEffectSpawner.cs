using MEC;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace TicTacMagic
{
    public class OnTileEffectSpawner : EffectSpawner
    {
        [SerializeField]
        private List<TileEffect> _effects;

        private Player _player;

        private TileField _tileField;

        private Tile _spawnTile;

        private EffectPool<TileEffect> _pool;


        [Inject]
        public void Construct(TileField tileField, PlayerSpawner playerSpawner) {
            _tileField = tileField;
            playerSpawner.OnPlayerSpawned += SetPlayer;
        }

        private void Start() {
            _pool = new EffectPool<TileEffect>(transform);
            _pool.Initialize(_effects);
        }

        private void Update() {
            if (_player != null && _isReady) {
                _spawnTile = ChoiseTileToSpawn();

                if (_spawnTile != null) {
                    _isReady = false;
                    SpawnWithCooldown();
                }
            }
        }

        public override void SpawnWithCooldown() {
            var effect = _pool.Get(SelectTileEffectByWeight());

            effect.Initialize(_spawnTile);
            effect.Run();

            Timing.RunCoroutine(_Cooldown().CancelWith(gameObject));
        }

        private TileEffect SelectTileEffectByWeight() {
            var effect = SelectEffectByWeight(_effects.Cast<IEffect>().ToList());

            return (TileEffect)effect;
        }

        private bool CanSpawnOn(Tile tile) {
            if (tile != _player.CurrentTile && tile.IsFree())
                return true;

            return false;
        }

        private Tile ChoiseTileToSpawn() {
            var rng = new System.Random();
            var tiles = _tileField.GetTiles().OrderBy(tile => rng.Next()).ToList();

            foreach (var tile in tiles)
                if (CanSpawnOn(tile))
                    return tile;
            return null;
        }

        private void SetPlayer(Player player) {
            _player = player;
        }
    }
}
