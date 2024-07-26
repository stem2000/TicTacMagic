using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class MovementToTile
    {
        private Tile currentTile;

        private Rigidbody2D rBody2D;
        private bool isMoving = false;

        public MovementToTile(Tile startingTile, Rigidbody2D rBody2D)
        {
            currentTile = startingTile;
            this.rBody2D = rBody2D;
        }

        public void Move(MoveDirection direction, float duration)
        {
            var tile = currentTile.GetNeighborByDirection(direction);

            if(tile != null)
            {
                Timing.KillCoroutines("MoveTo");
                Timing.RunCoroutine(MoveRoutine(tile, duration), Segment.FixedUpdate, "MoveTo");
            }
        }

        private IEnumerator<float> MoveRoutine(Tile tile, float speed)
        {
            currentTile = tile;

            while (rBody2D.position != tile.GetPosition())
            {
                Vector2 newPosition = Vector2.MoveTowards(rBody2D.position, tile.GetPosition(), speed * Time.fixedDeltaTime);
                rBody2D.MovePosition(newPosition);
                yield return Timing.WaitForOneFrame;
            }
        }
    }
}
