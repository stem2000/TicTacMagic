using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class PlayerMovement
    {
        public Tile CurrentTile{ get => _currentTile; }
        public Tile PointedTile { get => _pointedTile; }

        private Tile _pointedTile;
        private Tile _currentTile;
        private Rigidbody2D _rBody;
        private PlayerModel _playerModel;

        public PlayerMovement(Tile startingTile, Rigidbody2D rBody2D, PlayerModel playerModel)
        {
            _currentTile = _pointedTile = startingTile;
            this._rBody = rBody2D;
            this._playerModel = playerModel;
        }

        public void Move(MoveDirection direction)
        {
            UpdateCurrent();

            Tile tile = null;
            tile = _pointedTile.GetNeighborByDirection(direction); 
            tile = _currentTile.IsMyNeighbor(tile) || tile == _currentTile ? tile : null;
            

            if(tile != null && !tile.IsMoveBlocked())
            {
                _pointedTile = tile;
                Timing.KillCoroutines("MoveTo");
                Timing.RunCoroutine(MoveRoutine(tile, _playerModel.Speed).CancelWith(_rBody.gameObject), Segment.FixedUpdate, "MoveTo");
            }
        }

        private IEnumerator<float> MoveRoutine(Tile tile, float speed)
        {
            while (_rBody.position != tile.GetPosition())
            {
                Vector2 newPosition = Vector2.MoveTowards(_rBody.position, tile.GetPosition(), speed * Time.fixedDeltaTime);
                _rBody.MovePosition(newPosition);
                yield return Timing.WaitForOneFrame;
            }
        }

        private void UpdateCurrent()
        {
            if(TilePromter.Instance.GetTileClosestTo(_rBody.position) == _pointedTile)
                _currentTile = _pointedTile;
        }
    }
}
