using MEC;
using UnityEngine;

namespace TicTacMagic
{
    public class Player : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 30f;
        private Rigidbody2D rBody2D;
        private MovementToTile pMovement;
        private IInputProvider inputProvider;


        public void Initialize(Tile startingTile, IInputProvider inputProvider)
        {
            rBody2D = GetComponent<Rigidbody2D>();
            pMovement = new MovementToTile(startingTile, rBody2D);
            this.inputProvider = inputProvider;
        }


        public void Update()
        {
            var direction = inputProvider.GetMoveDirection();
            if(direction != MoveDirection.None)
                Debug.Log(direction);
            pMovement.Move(direction, moveSpeed);
        }
    }
}
