using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class Movement
    {
        public Tile PointedTile;
        public Tile CurrentTile;
        public TileField Field;
        public Rigidbody2D Rbody;
        public PlayerData Data;


        public void Move(MoveDirection direction)
        {
            UpdateCurrent();

            Tile tile = null;
            tile = PointedTile.GetNeighborByDirection(direction); 
            tile = CurrentTile.IsMyNeighbor(tile) || tile == CurrentTile ? tile : null;
            

            if(tile != null && !tile.IsMoveBlocked())
            {
                PointedTile = tile;
                Timing.KillCoroutines("MoveTo");
                Timing.RunCoroutine(MoveRoutine(tile, Data.Speed).CancelWith(Rbody.gameObject), Segment.FixedUpdate, "MoveTo");
            }
        }

        private IEnumerator<float> MoveRoutine(Tile tile, float speed)
        {
            while (Rbody.position != tile.GetPosition())
            {
                Vector2 newPosition = Vector2.MoveTowards(Rbody.position, tile.GetPosition(), speed * Time.fixedDeltaTime);
                Rbody.MovePosition(newPosition);
                yield return Timing.WaitForOneFrame;
            }
        }

        private void UpdateCurrent()
        {
            if(Field.GetTileClosestTo(Rbody.position) == PointedTile)
                CurrentTile = PointedTile;
        }
    }
}
