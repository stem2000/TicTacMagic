using System;
using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public class Player : MonoBehaviour, IDamageable, IHealable
    {
        public event Action OnDead;
        public event Action<float> OnDamaged;
        public event Action<float> OnHealed;

        [SerializeField] 
        private PlayerModel _playerModel;
        [SerializeField] 
        private PlayerView _playerView;

        private Rigidbody2D rBody2D;
        private PlayerMovement playerMovement;        
        private IDirectionProvider inputProvider;

        public Vector2 PlayerPosition => rBody2D.position;

        public Tile PointedTile { get => playerMovement.PointedTile; }
        public Tile CurrentTile { get => playerMovement.CurrentTile; }

        public void Initialize(Tile startingTile, IDirectionProvider inputProvider)
        {
            rBody2D = GetComponent<Rigidbody2D>();
            playerMovement = new PlayerMovement(startingTile, rBody2D, _playerModel);
            this.inputProvider = inputProvider;

            _playerModel = Instantiate(_playerModel);
        }

        public void GetDamage(float damage)
        {
            _playerModel.Hp -= damage;
            OnDamaged?.Invoke(_playerModel.Hp);

            if (_playerModel.Hp <= 0)
                SelfDestroy();
        }

        public void GetHp(float hp)
        {
            _playerModel.Hp += hp;
            if(_playerModel.Hp > 100)
                _playerModel.Hp = 100;

            OnHealed?.Invoke(_playerModel.Hp);
        }

        private void SelfDestroy()
        {
            OnDead?.Invoke();
        }

        public void Update()
        {
            var direction = inputProvider.GetMoveDirection();

            playerMovement.Move(direction);
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(playerMovement.CurrentTile.transform.position, 0.5f);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(playerMovement.PointedTile.transform.position, 0.5f);
        }
    }
}
