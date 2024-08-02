using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public class Player : MonoBehaviour, IPlayer, IDamageable, IHealable
    {        
        private Rigidbody2D rBody2D;
        private PlayerMovement playerMovement;        
        private IInputProvider inputProvider;

        [SerializeField] private UnityEvent onPlayerDeath;
        [SerializeField] private UnityEvent<float> onPlayerDamaged;
        [SerializeField] private UnityEvent<float> onPlayerHealed;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private PlayerView playerView;

        public IPlayerStatsProvider PlayerStatsProvider => playerStats;

        public Vector2 PlayerPosition => rBody2D.position;

        public Tile PointedTile { get => playerMovement.PointedTile; }
        public Tile CurrentTile { get => playerMovement.CurrentTile; }

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
                SelfDestroy();
        }

        public void GetHp(float hp)
        {
            playerStats.hp += hp;
            if(playerStats.hp > 100)
                playerStats.hp = 100;

            onPlayerHealed?.Invoke(playerStats.hp);
        }

        public void AddListenerToPlayerDamaged(UnityAction<float> listener)
        {
            onPlayerDamaged.AddListener(listener);
        }

        public void AddListenerToPlayerHealed(UnityAction<float> listener)
        {
            onPlayerHealed.AddListener(listener);
        }

        public void AddListenerToPlayerDeath(UnityAction listener)
        {
            onPlayerDeath.AddListener(listener);
        }

        private void SelfDestroy()
        {
            onPlayerDeath?.Invoke();
            onPlayerDamaged.RemoveAllListeners();
            onPlayerDeath.RemoveAllListeners();
        }

        public void Update()
        {
            var direction = inputProvider.GetMoveDirection();

            playerMovement.Move(direction);
        }

        public void OnDrawGizmos()
        {
            //Gizmos.color = Color.green;
            //Gizmos.DrawSphere(playerMovement.CurrentTile.transform.position, 0.5f);
            //Gizmos.color = Color.red;
            //Gizmos.DrawSphere(playerMovement.PointedTile.transform.position, 0.5f);
        }
    }
}
