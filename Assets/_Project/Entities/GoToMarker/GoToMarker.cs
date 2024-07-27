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
