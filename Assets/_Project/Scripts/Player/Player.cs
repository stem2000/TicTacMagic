using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace TicTacMagic {
    public class Player : MonoBehaviour, IDamageable, IHealable
    {
        public event Action OnDeath;
        public event Action<float> OnDamaged;
        public event Action<float> OnHealed;

        [SerializeField] 
        private PlayerData playerData;

        [SerializeField] 
        private PlayerView playerView;

        private Movement movement;        
        private IInputProvider inputProvider;

        public Tile PointedTile { get => movement.PointedTile; }
        public Tile CurrentTile { get => movement.CurrentTile; }


        public void GetDamage(float damage)
        {
            this.playerData.Hp -= damage;
            this.OnDamaged?.Invoke(playerData.Hp);

            if (this.playerData.Hp <= 0)
                SelfDestroy();
        }

        public void GetHp(float hp)
        {
            this.playerData.Hp += hp;
            if(this.playerData.Hp > 100)
                this.playerData.Hp = 100;

            this.OnHealed?.Invoke(this.playerData.Hp);
        }

        private void SelfDestroy()
        {
            this.OnDeath?.Invoke();
        }

        private void Awake() {
            this.movement = new Movement();
        }

        private void Update()
        {
            var direction = this.inputProvider.GetMoveDirection();

            this.movement.Move(direction);
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(movement.CurrentTile.transform.position, 0.5f);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(movement.PointedTile.transform.position, 0.5f);
        }

        public class PlayerBuilder {
            Player player;

            public PlayerBuilder InsantiatePlayer(Player player, Tile tile) {
                this.player = Instantiate(player, tile.transform.position, Quaternion.identity);
                this.player.movement.CurrentTile = this.player.movement.PointedTile = tile;
                this.player.movement.Rbody = this.player.GetComponent<Rigidbody2D>();
                this.player.movement.Data = this.player.playerData;
                return this;
            }

            public PlayerBuilder SetTileField(TileField tileField) {
                this.player.movement.Field = tileField;

                return this;
            }

            public PlayerBuilder SetInputProvider(IInputProvider inputProvider) {
                this.player.inputProvider = inputProvider;

                return this;
            }

            public Player GetInstance() {
                return this.player;
            }
        }
    }
}
