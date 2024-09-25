using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace TicTacMagic
{
    public class Player : MonoBehaviour, IDamageable, IHealable
    {
        public event Action OnDead;
        public event Action<float> OnDamaged;
        public event Action<float> OnHealed;

        [SerializeField] 
        private PlayerModel playerModel;
        [SerializeField] 
        private PlayerView playerView;

        private Movement movement;        
        private IInputProvider inputProvider;

        public Tile PointedTile { get => movement.PointedTile; }
        public Tile CurrentTile { get => movement.CurrentTile; }

        public void GetDamage(float damage)
        {
            this.playerModel.Hp -= damage;
            this.OnDamaged?.Invoke(playerModel.Hp);

            if (this.playerModel.Hp <= 0)
                SelfDestroy();
        }

        public void GetHp(float hp)
        {
            this.playerModel.Hp += hp;
            if(this.playerModel.Hp > 100)
                this.playerModel.Hp = 100;

            this.OnHealed?.Invoke(this.playerModel.Hp);
        }

        private void SelfDestroy()
        {
            this.OnDead?.Invoke();
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
                this.player.movement.Model = this.player.playerModel;
                return this;
            }

            public PlayerBuilder SetTileField(TileField tileField) {
                this.player.movement.Field = tileField;

                return this;
            }

            public PlayerBuilder SetDefaultInputProvider() {
                InputActionsWrapper actionsWrapper = new InputActionsWrapper();

                this.player.inputProvider = actionsWrapper;
                return this;
            }
        }
    }
}
