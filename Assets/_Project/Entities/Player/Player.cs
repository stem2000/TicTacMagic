using MEC;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public class Player : MonoBehaviour, IPlayer, IDamageable
    {        
        private Rigidbody2D rBody2D;
        private PlayerMovement playerMovement;        
        private IInputProvider inputProvider;
        private UnityEvent onPlayerDeath;
        private UnityEvent<float> onPlayerDamaged;

        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private PlayerView playerView;

        public IPlayerStatsProvider PlayerStatsProvider => playerStats;

        public void Initialize(Tile startingTile, IInputProvider inputProvider)
        {
            rBody2D = GetComponent<Rigidbody2D>();
            playerMovement = new PlayerMovement(startingTile, rBody2D, playerStats);
            onPlayerDeath = new UnityEvent();
            onPlayerDamaged = new UnityEvent<float>();
            this.inputProvider = inputProvider;

            InitializePlayerView();
        }

        private void InitializePlayerView()
        {
            if(playerView != null)
            {
                playerView = Instantiate(playerView, transform);
                playerView.Initialize(this);
            }
        }

        public void GetDamage(float damage)
        {
            playerStats.hp -= damage;
            onPlayerDamaged?.Invoke(playerStats.hp);

            if (playerStats.hp <= 0)
                DestroyPlayer();
        }

        public void AddListenerToPlayerDamaged(UnityAction<float> listener)
        {
            onPlayerDamaged.AddListener(listener);
        }

        public void AddListenerToPlayerDeath(UnityAction listener)
        {
            onPlayerDeath.AddListener(listener);
        }

        private void DestroyPlayer()
        {
            onPlayerDeath?.Invoke();
            onPlayerDamaged.RemoveAllListeners();
            onPlayerDeath.RemoveAllListeners();
            Destroy(gameObject);
        }

        public void Update()
        {
            var direction = inputProvider.GetMoveDirection();

            playerMovement.Move(direction);
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
