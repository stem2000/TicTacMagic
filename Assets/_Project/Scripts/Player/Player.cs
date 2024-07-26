using MEC;
using UnityEngine;

namespace TicTacMagic
{
    public class Player : MonoBehaviour
    {
        [SerializeField] float moveDuration = 0.25f;
        private Rigidbody2D rBody2D;
        private MovementToTile pMovement;
        private KeyCode lastKeyCode = KeyCode.None;


        public void Initialize(Tile startingTile)
        {
            rBody2D = GetComponent<Rigidbody2D>();
            pMovement = new MovementToTile(startingTile, rBody2D);
        }


        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                lastKeyCode = KeyCode.A;
            if (Input.GetKeyDown(KeyCode.D))
                lastKeyCode = KeyCode.D;
            if (Input.GetKeyDown(KeyCode.W))
                lastKeyCode = KeyCode.W;
            if (Input.GetKeyDown(KeyCode.S))
                lastKeyCode = KeyCode.S;

            Tile tile = null;

            if (lastKeyCode == KeyCode.A)
                tile = GetTileByDirection(MoveDirection.Left);
            else if(lastKeyCode == KeyCode.D)
                tile = GetTileByDirection(MoveDirection.Right);
            else if (lastKeyCode == KeyCode.W)
                tile = GetTileByDirection(MoveDirection.Up);
            else if (lastKeyCode == KeyCode.S)
                tile = GetTileByDirection(MoveDirection.Down);

            if(tile != null)
            {
                pMovement.MoveTo(tile, moveDuration);
                lastKeyCode = KeyCode.None;
            }
        }


        private Tile GetTileByDirection(MoveDirection direction)
        {
            var currentTile = pMovement.GetCurrentTile();

            switch (direction)
            {
                case MoveDirection.Left:        
                    return currentTile.GetLeftTile();
                case MoveDirection.Right:
                    return currentTile.GetRightTile();
                case MoveDirection.Up:
                    return currentTile.GetUpTile();
                case MoveDirection.Down:
                    return currentTile.GetDownTile();
            }

            return null;
        }

        enum MoveDirection
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}
