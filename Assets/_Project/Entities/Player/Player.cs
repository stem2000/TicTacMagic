using MEC;
using UnityEngine;

namespace TicTacMagic
{
    public class Player : MonoBehaviour, IPlayer
    {        
        public Vector2 CurrentTilePosition { get { return playerMovement.CurrentTilePosition; } }
        public Vector2 RealBodyPosition { get { return rBody2D.position; } }
        public bool IsOnCurrentTile { get { return playerMovement.IsOnCurrentTile; } }

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

    }
}
