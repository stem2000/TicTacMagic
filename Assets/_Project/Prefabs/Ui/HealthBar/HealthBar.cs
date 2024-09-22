using UnityEngine;
using UnityEngine.UI;

namespace TicTacMagic
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;


        public void SetHp(float hp)
        {
            healthSlider.value = hp;
        }
    }
}
