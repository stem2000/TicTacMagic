using Unity.VisualScripting;
using UnityEngine;

namespace TicTacMagic
{
    public class PlayerView : MonoBehaviour
    {
        private IPlayer player;


        public void Initialize(IPlayer player)
        {
            this.player = player;
        }


    }
}
