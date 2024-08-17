using UnityEngine.InputSystem;

namespace TicTacMagic
{
    public class PlayerInputActionsWrapper : IDirectionProvider
    {
        PlayerInputActions inputActions;

        InputAction moveLeft;
        InputAction moveRight;
        InputAction moveUp;
        InputAction moveDown;

        MoveDirection currentDirection = MoveDirection.None;


        public PlayerInputActionsWrapper()
        {
            inputActions = new PlayerInputActions();
            inputActions.Player.Enable();

            moveLeft = inputActions.Player.MoveLeft;
            moveRight = inputActions.Player.MoveRight;
            moveUp = inputActions.Player.MoveUp;
            moveDown = inputActions.Player.MoveDown;

            moveUp.performed += ctx => UpdateMoveDirection(MoveDirection.Up, moveUp);
            moveDown.performed += ctx => UpdateMoveDirection(MoveDirection.Down, moveDown);
            moveLeft.performed += ctx => UpdateMoveDirection(MoveDirection.Left, moveLeft);
            moveRight.performed += ctx => UpdateMoveDirection(MoveDirection.Right, moveRight);
        }

        public MoveDirection GetMoveDirection()
        {
            var direction = currentDirection;

            currentDirection = MoveDirection.None;
            return direction;
        }

        private void UpdateMoveDirection(MoveDirection direction, InputAction action)
        {
            currentDirection = direction;
        }
    }
}
