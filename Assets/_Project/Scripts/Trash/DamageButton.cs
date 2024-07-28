using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacMagic
{
    public class DamageButton : MonoBehaviour
    {
        private Button button;
        private IDamageable player;

        public void Start()
        {
            button = GetComponent<Button>();
            player = FindObjectOfType<Player>();

            button.onClick.AddListener(MakeDamageToPlayer);
        }

        private void MakeDamageToPlayer()
        {
            player.GetDamage(10);
        }
    }
}
