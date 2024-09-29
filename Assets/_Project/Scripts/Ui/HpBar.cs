using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TicTacMagic
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] 
        private Slider _hpSlider;

        [SerializeField]
        private Player _player;


        [Inject]
        public void Construct(PlayerSpawner playerSpawner) {
            playerSpawner.OnPlayerSpawned += SubscribeToPlayer;
        }

        public void UpdateHpBar(float hp){
            _hpSlider.value = hp;
        }

        public void SubscribeToPlayer(Player player) {
            player.OnDamaged += UpdateHpBar;
            player.OnHealed += UpdateHpBar;
        }
    }
}
