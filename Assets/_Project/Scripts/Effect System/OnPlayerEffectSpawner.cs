using UnityEngine;
using Zenject;
using MEC;
using System.Collections.Generic;
using System.Linq;

namespace TicTacMagic
{
    public class OnPlayerEffectSpawner : EffectSpawner {

        [SerializeField]
        private List<OnPlayerEffect> effects;

        [SerializeField]
        private float cooldown = 2f;

        private TileField tileField;
        private Player player;
        private bool isReady = true;

        [Inject]
        public void Construct(TileField tileField, PlayerSpawner playerSpawner) {
            this.tileField = tileField;
            playerSpawner.OnPlayerSpawned += SetPlayer;
        }


        public override void SpawnWithCooldown() {
            var effect = Instantiate(
                SelectPlayerEffectByWeight(), 
                this.player.transform.position,
                Quaternion.identity,
                this.transform);

            effect.RunOnPlayer();
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
