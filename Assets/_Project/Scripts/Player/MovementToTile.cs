using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class MovementToTile
    {
        private Tile currentTile;
        private Tile pastTile;
        private Rigidbody2D rBody2D;
        private bool isMoving = false;

        public MovementToTile(Tile startingTile, Rigidbody2D rBody2D)
        {
            currentTile = startingTile;
            this.rBody2D = rBody2D;
        }

        public void MoveTo(Tile tile, float duration)
        {
            if (!isMoving)
            {
                Timing.RunCoroutine(MoveToRoutine(tile, duration), Segment.FixedUpdate, "MoveTo");
                isMoving = true;
            }
        }

        public Tile GetCurrentTile()
        {
            return currentTile;
        }

        private IEnumerator<float> MoveToRoutine(Tile tile, float duration)
        {
            var elapsedTime = 0f;
            var startPosition = currentTile.GetPosition();

            pastTile = currentTile;
            currentTile = tile;

            while (elapsedTime < duration)
            {
                var nextPosition = Vector3.Lerp(startPosition, tile.GetPosition(), elapsedTime / duration);
                rBody2D.MovePosition(nextPosition);
                elapsedTime += Time.fixedDeltaTime;
                yield return Timing.WaitForOneFrame;
            }

            rBody2D.MovePosition(tile.GetPosition()); 
            isMoving = false;
        }
    }
}
