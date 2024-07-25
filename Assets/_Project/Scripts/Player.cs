using System.Collections;
using UnityEngine;

namespace TicTacMagic
{
    public class Player : MonoBehaviour
    {
        [HideInInspector] public Tile CurrentTile;

        [SerializeField] float moveDuration = 0.25f;
        private Rigidbody2D rBody2D;
        private bool movementIsBlocked = false;
        private KeyCode lastKeyCode = KeyCode.None;


        public void Awake()
        {
            rBody2D = GetComponent<Rigidbody2D>();
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

            if (movementIsBlocked)
                return;

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
                StartCoroutine(MoveToTile(tile, moveDuration));
                CurrentTile = tile;
                movementIsBlocked = true;
            }
        }


        private Tile GetTileByDirection(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Left:        
                    return CurrentTile.GetLeftTile();
                case MoveDirection.Right:
                    return CurrentTile.GetRightTile();
                case MoveDirection.Up:
                    return CurrentTile.GetUpTile();
                case MoveDirection.Down:
                    return CurrentTile.GetDownTile();
            }

            return null;
        }


        private IEnumerator MoveToTile(Tile tile, float duration)
        {
            var startPosition = transform.position;
            var elapsedTime = 0f;

            lastKeyCode = KeyCode.None;
            movementIsBlocked = true;

            while (elapsedTime < moveDuration) 
            {
                var nextPosition = Vector3.Lerp(startPosition, tile.GetPosition(), elapsedTime / duration);
                rBody2D.MovePosition(nextPosition);
                elapsedTime += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }

            rBody2D.MovePosition(tile.GetPosition()); // Убедимся, что объект точно достиг целевой позиции
            movementIsBlocked = false;
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
