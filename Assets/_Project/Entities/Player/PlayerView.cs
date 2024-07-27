using Unity.VisualScripting;
using UnityEngine;

namespace TicTacMagic
{
    public class PlayerView : MonoBehaviour
    {
        private IPlayer player;

        [SerializeField] private GoToMarker goToMarker;

        public void Initialize(IPlayer player)
        {
            this.player = player;
            InitializeMarker();
        }

        private void InitializeMarker()
        {
            if (goToMarker != null)
            {
                goToMarker = Instantiate(goToMarker);
                goToMarker.Initialize(player);
            }
        }

    }
}
