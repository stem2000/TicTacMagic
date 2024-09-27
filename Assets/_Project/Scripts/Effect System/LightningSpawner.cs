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

        [SerializeField]
        private float cooldown = 2f;

        private EffectPool<OnPlayerEffect> pool;

        private OnTileEffectSpawner onTileSpawner;

        private TileField tileField;

        private Player player;

        private bool isReady = true;


        [Inject]
        public void Construct(TileField tileField, PlayerSpawner playerSpawner) {
            this.tileField = tileField;
            playerSpawner.OnPlayerSpawned += SetPlayer;
        }

        private void Start() {
            this.onTileSpawner = GetComponent<OnTileEffectSpawner>();
            this.pool = new EffectPool<OnPlayerEffect>(this.transform);
            this.pool.Initialize(effects);
        }


        public override void SpawnWithCooldown() {
            var effect = this.pool.Get(SelectPlayerEffectByWeight());
                
            effect.Activate(player.transform.position);
            effect.Run();
            Timing.RunCoroutine(_Cooldown());
        }


        private IEnumerator<float> _Cooldown() {
            yield return Timing.WaitForSeconds(cooldown);
            isReady = true;
        }

        private OnPlayerEffect SelectPlayerEffectByWeight() {
            var effect = SelectEffectByWeight(effects.Cast<IEffect>().ToList());

            return (OnPlayerEffect)effect;
        }

        private void SetPlayer(Player player) {
            this.player = player;
        }

        private void Update() {
            if(player != null && isReady) {
                isReady = false;
                SpawnWithCooldown();
            }
        }
    }
}
