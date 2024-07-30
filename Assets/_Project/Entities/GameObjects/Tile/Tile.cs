using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private Tile up;
        [SerializeField] private Tile down;
        [SerializeField] private Tile left;
        [SerializeField] private Tile right;

        [SerializeField] private List<Tile> neighbours;
        private OnTileObject onTileObject;

        public Vector2 GetPosition()
        {
            return transform.position;
        }

        public Tile GetLeftTile()
        {
            return left;
        }

        public Tile GetRightTile()
        {
            return right;
        }

        public Tile GetUpTile()
        {
            return up;
        }

        public Tile GetDownTile()
        {
            return down;
        }

        public bool IsMyNeighbor(Tile tile)
        {
            foreach(var neighbour in neighbours)
                if(tile == neighbour)
                    return true;

            return false;
        }

        public Tile GetNeighborByDirection(MoveDirection direction)
        {
            if (direction == MoveDirection.Up) return up;
            if (direction == MoveDirection.Down) return down;
            if (direction == MoveDirection.Left) return left;
            if (direction == MoveDirection.Right) return right;

            return null;
        }

        public void SetOnTileObject(OnTileObject @object)
        {
            onTileObject = @object;
        }

        public bool IsMoveClosed()
        {
            return onTileObject.IsMoveCloser();
        }


    }
}
