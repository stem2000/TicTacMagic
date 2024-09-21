using UnityEngine;
using UnityEngine.UI;

namespace TicTacMagic
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;

        public void Initalize(IPlayer player)
        {
            healthSlider.maxValue = player.PlayerStatsProvider.Hp;
            healthSlider.value = healthSlider.maxValue;
            player.AddListenerToPlayerDamaged(SetHp);
            player.AddListenerToPlayerHealed(SetHp);
        }

        public void SetHp(float hp)
        {
            healthSlider.value = hp;
        }
    }
}
