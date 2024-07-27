using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace TicTacMagic
{
    public class GoToMarker : MonoBehaviour
    {
        private IPlayer player;

        [SerializeField] GameObject markerView;


        public void Initialize(IPlayer player)
        {
            this.player = player;
        }

        private void Update()
        {
            if(((Vector2)transform.position - player.RealBodyPosition).magnitude <= 0.1f)
                Hide();
            else
            {
                GoToPosition(player.CurrentTilePosition);
                Reveal();
            }
        }

        private void GoToPosition(Vector2 position)
        {
            transform.position = position;
        }

        private void Hide()
        {
            markerView.SetActive(false);
        }

        private void Reveal()
        {
            markerView.SetActive(true);
        }
    }
}
