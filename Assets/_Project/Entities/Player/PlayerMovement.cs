using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class PlayerMovement
    {
        private Tile pointedTile;
        private Tile currentTile;
        TilePromter tilePromter;
        private Rigidbody2D rBody2D;
        private IPlayerStatsProvider playerStats;

        public PlayerMovement(Tile startingTile, Rigidbody2D rBody2D, IPlayerStatsProvider playerStats)
        {
            tilePromter = new TilePromter();

            currentTile = pointedTile = startingTile;
            this.rBody2D = rBody2D;
            this.playerStats = playerStats;
        }

        public void Move(MoveDirection direction)
        {
            Tile tile = null;

            UpdateCurrent();

            tile = pointedTile.GetNeighborByDirection(direction); 
            tile = currentTile.IsMyNeighbor(tile) ? tile : null;
            

            if(tile != null)
            {
                pointedTile = tile;
                Timing.KillCoroutines("MoveTo");
                Timing.RunCoroutine(MoveRoutine(tile, playerStats.Speed), Segment.FixedUpdate, "MoveTo");
            }
        }

        private IEnumerator<float> MoveRoutine(Tile tile, float speed)
        {
            while (rBody2D.position != tile.GetPosition())
            {
                Vector2 newPosition = Vector2.MoveTowards(rBody2D.position, tile.GetPosition(), speed * Time.fixedDeltaTime);
                rBody2D.MovePosition(newPosition);
                yield return Timing.WaitForOneFrame;
            }
        }

        private void UpdateCurrent()
        {
            if(tilePromter.GetClosestTo(rBody2D.position) == pointedTile)
                currentTile = pointedTile;
        }
    }
}
