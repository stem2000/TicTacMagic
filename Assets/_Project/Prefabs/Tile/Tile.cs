using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace TicTacMagic
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] 
        public Tile up;

        [SerializeField] 
        public Tile down;

        [SerializeField] 
        public Tile left;

        [SerializeField] 
        public Tile right;

        [SerializeField] 
        public List<Tile> neighbours;

        private TileEffect _tileEffect;

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

        public bool IsMyNeighbor(Tile tile) {
            foreach(var neighbour in neighbours)
                if(tile == neighbour)
                    return true;

            return false;
        }

        public Tile GetNeighborByDirection(MoveDirection direction) {
            if (direction == MoveDirection.Up) return up;
            if (direction == MoveDirection.Down) return down;
            if (direction == MoveDirection.Left) return left;
            if (direction == MoveDirection.Right) return right;

            return null;
        }

        public void UnfreeWith(TileEffect @object) {
            _tileEffect = @object;
        }

        public void Free() {
            _tileEffect = null;
        }

        public bool IsMoveBlocked() {
            if(_tileEffect != null)
                return _tileEffect.IsMoveBlocker();
            return false;
        }

        public bool IsFree() {
            if(_tileEffect == null)
                return true;
            
            return false;
        }

        public List<Tile> GetNeighbours() {
            return neighbours;
        }

    }
}
