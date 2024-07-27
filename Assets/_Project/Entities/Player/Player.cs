using MEC;
using UnityEngine;

namespace TicTacMagic
{
    public class Player : MonoBehaviour, IPlayer
    {        
        private Rigidbody2D rBody2D;
        private PlayerMovement playerMovement;        
        private IInputProvider inputProvider;

        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private PlayerView playerView;

        public void Initialize(Tile startingTile, IInputProvider inputProvider)
        {
            rBody2D = GetComponent<Rigidbody2D>();
            playerMovement = new PlayerMovement(startingTile, rBody2D, playerStats);
            this.inputProvider = inputProvider;

            InitializePlayerView();
        }


        public void Update()
        {
            var direction = inputProvider.GetMoveDirection();
            
            playerMovement.Move(direction);
        }

        private void InitializePlayerView()
        {
            if(playerView != null)
            {
                playerView = Instantiate(playerView, transform);
                playerView.Initialize(this);
            }
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(playerMovement.CurrentTilePosition, 0.5f);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(playerMovement.PointedTilePosition, 0.5f);
        }

    }
}
