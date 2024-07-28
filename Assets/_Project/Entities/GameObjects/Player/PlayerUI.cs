using UnityEngine;

namespace TicTacMagic
{
    public class PlayerUI : MonoBehaviour
    {
        private IPlayer player;
        private HealthBar hpBar;

        public void Initialize(IPlayer player)
        {
            this.player = player;
        }


    }
}
